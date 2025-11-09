pipeline {
  agent any

  environment {
    ENV_NAME = """${
      (env.BRANCH_NAME == 'main')    ? 'main' :
      (env.BRANCH_NAME == 'staging') ? 'staging' :
      (env.BRANCH_NAME == 'qa')      ? 'qa' :
      (env.BRANCH_NAME == 'dev' || env.BRANCH_NAME == 'develop') ? 'dev' :
      'dev'
    }"""
    COMPOSE_DIR = "Devops/${ENV_NAME}"
    ENV_FILE    = "Vards/.env-${ENV_NAME}"
    PROJECT     = "schoolme-${ENV_NAME}" // aísla redes/volúmenes por ambiente
    IMAGE_TAG   = "schoolme/api:${ENV_NAME}-${env.BUILD_NUMBER}"
    IMAGE_LATEST= "schoolme/api:${ENV_NAME}-latest"
    DOCKER_HOST = 'tcp://host.docker.internal:2375'
  }

  options {
    timestamps()
    // ansiColor('xterm')
    buildDiscarder(logRotator(numToKeepStr: '20'))
  }

  stages {

    stage('Checkout') {
      steps {
        checkout scm
        sh 'ls -la && echo "Branch: ${BRANCH_NAME}  ENV: ${ENV_NAME}"'
      }
    }

    // >>> NUEVA ETAPA <<<
    stage('Prepare .env (inject secrets)') {
      steps {
        withCredentials([
          string(credentialsId: 'pg-password',          variable: 'PG_PASS'),
          string(credentialsId: 'azure-storage-conn',   variable: 'AZ_CONN')
        ]) {
          sh '''
            set -e
            mkdir -p Vards

            ENVF="${ENV_FILE}"
            if [ ! -f "$ENVF" ]; then
              echo "WARNING: $ENVF no existe en el workspace. Crea el .env del ambiente en Vards/ antes de desplegar."
              # Si quisieras crearlo mínimo:
              # echo -e "ASPNETCORE_ENVIRONMENT=Production" > "$ENVF"
            fi

            upsert() {
              VAR="$1"; VAL="$2"; FILE="$3"
              [ -f "$FILE" ] || return 0
              if grep -qE "^${VAR}=" "$FILE"; then
                sed -i "s|^${VAR}=.*|${VAR}=${VAL}|" "$FILE"
              else
                echo "${VAR}=${VAL}" >> "$FILE"
              fi
            }

            # Inyectar/actualizar secretos en el .env del ambiente
            upsert "POSTGRES_PASSWORD"        "${PG_PASS}" "$ENVF"
            upsert "AZURE_STORAGE_CONNECTION" "${AZ_CONN}" "$ENVF"

            echo "Preview (secrets ocultos):"
            if [ -f "$ENVF" ]; then
              sed 's/\\(AccountKey=\\)[^;]*/\\1***REDACTED***/' "$ENVF" || true
            fi
          '''
        }
      }
    }

    stage('Validar archivos') {
      steps {
        sh '''
          test -f "${COMPOSE_DIR}/docker-compose.yml" || (echo "Falta compose: ${COMPOSE_DIR}/docker-compose.yml" && exit 1)
          test -f "${ENV_FILE}" || (echo "Falta env: ${ENV_FILE}" && exit 1)
          echo "Usando compose: ${COMPOSE_DIR}/docker-compose.yml"
          echo "Usando env    : ${ENV_FILE}"
        '''
      }
    }

    stage('Doctor Docker') {
      steps {
        sh '''
          set -e
          echo "DOCKER_HOST=${DOCKER_HOST:-<no-set>}"
          docker --version
          docker compose version || docker-compose --version
        '''
      }
    }

    stage('(Optional) Push image') {
      when { expression { false } } // pon true si deseas publicar a un registry
      steps {
        withCredentials([usernamePassword(credentialsId: 'dockerhub-schoolme', usernameVariable: 'DH_USER', passwordVariable: 'DH_PASS')]) {
          sh '''
            echo "$DH_PASS" | docker login -u "$DH_USER" --password-stdin
            docker push "${IMAGE_TAG}"
            docker push "${IMAGE_LATEST}"
          '''
        }
      }
    }

    stage('Deploy (docker compose up)') {
      steps {
        sh '''
          set -e
          docker compose -p "${PROJECT}" --env-file "${ENV_FILE}" -f "${COMPOSE_DIR}/docker-compose.yml" down
          docker compose -p "${PROJECT}" --env-file "${ENV_FILE}" -f "${COMPOSE_DIR}/docker-compose.yml" up -d --build
        '''
      }
    }

    stage('Migrations (opcional)') {
      steps {
        sh '''
          set -e
          # Si tienes un servicio 'migrator' definido en el compose:
          if docker compose -p "${PROJECT}" --env-file "${ENV_FILE}" -f "${COMPOSE_DIR}/docker-compose.yml" ps migrator >/dev/null 2>&1; then
            echo "Ejecutando migrator..."
            docker compose -p "${PROJECT}" --env-file "${ENV_FILE}" -f "${COMPOSE_DIR}/docker-compose.yml" run --rm migrator
          else
            echo "No hay servicio migrator, saltando."
          fi
        '''
      }
    }

    stage('Healthcheck') {
      steps {
        sh '''
          set -e
          echo "Esperando 5s..."
          sleep 5
          docker compose -p "${PROJECT}" --env-file "${ENV_FILE}" -f "${COMPOSE_DIR}/docker-compose.yml" ps
        '''
      }
    }
  }

  post {
    always {
      sh 'docker images | head -n 20 || true'
    }
    success {
      echo "OK: ${ENV_NAME}"
    }
    failure {
      echo "FAIL: ${ENV_NAME}"
    }
  }
}
