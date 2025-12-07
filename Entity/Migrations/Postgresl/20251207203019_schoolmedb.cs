using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.Migrations.Postgresl
{
    /// <inheritdoc />
    public partial class schoolmedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "business");

            migrationBuilder.EnsureSchema(
                name: "parameters");

            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "agenda",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agenda", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departamet",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "documentType",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Acronym = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "eps",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eps", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "form",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_form", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grade",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "materialStatus",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materialStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "module",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    DataJson = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rh",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type_answare",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_answare", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "munisipality",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    departametId = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_munisipality", x => x.id);
                    table.ForeignKey(
                        name: "FK_munisipality_departamet_departametId",
                        column: x => x.departametId,
                        principalSchema: "parameters",
                        principalTable: "departamet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "person",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentTypeId = table.Column<int>(type: "integer", nullable: false),
                    identification = table.Column<long>(type: "bigint", nullable: false),
                    fisrtName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    secondName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    secondLastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone = table.Column<long>(type: "bigint", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                    table.ForeignKey(
                        name: "FK_person_documentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalSchema: "parameters",
                        principalTable: "documentType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "group",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    grade_id = table.Column<int>(type: "integer", nullable: false),
                    amount_students = table.Column<int>(type: "integer", nullable: false),
                    agenda_id = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group", x => x.id);
                    table.ForeignKey(
                        name: "fk_group_agenda",
                        column: x => x.agenda_id,
                        principalSchema: "business",
                        principalTable: "agenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_group_grade",
                        column: x => x.grade_id,
                        principalSchema: "parameters",
                        principalTable: "grade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "moduleForm",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    module_id = table.Column<int>(type: "integer", nullable: false),
                    form_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moduleForm", x => x.id);
                    table.ForeignKey(
                        name: "FK_moduleForm_form_form_id",
                        column: x => x.form_id,
                        principalSchema: "security",
                        principalTable: "form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_moduleForm_module_module_id",
                        column: x => x.module_id,
                        principalSchema: "security",
                        principalTable: "module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rolFormPermission",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rol_id = table.Column<int>(type: "integer", nullable: false),
                    form_id = table.Column<int>(type: "integer", nullable: false),
                    permission_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolFormPermission", x => x.id);
                    table.ForeignKey(
                        name: "FK_rolFormPermission_form_form_id",
                        column: x => x.form_id,
                        principalSchema: "security",
                        principalTable: "form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rolFormPermission_permission_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "security",
                        principalTable: "permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rolFormPermission_rol_rol_id",
                        column: x => x.rol_id,
                        principalSchema: "security",
                        principalTable: "rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "question",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    type_answer_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question", x => x.id);
                    table.ForeignKey(
                        name: "FK_question_type_answare_type_answer_id",
                        column: x => x.type_answer_id,
                        principalSchema: "parameters",
                        principalTable: "type_answare",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dataBasic",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    personaId = table.Column<int>(type: "integer", nullable: false),
                    rhId = table.Column<int>(type: "integer", nullable: false),
                    adress = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    birthDate = table.Column<DateTime>(type: "date", nullable: false),
                    stratumStatus = table.Column<int>(type: "integer", nullable: false),
                    materialStatusId = table.Column<int>(type: "integer", nullable: false),
                    epsId = table.Column<int>(type: "integer", nullable: false),
                    munisipalityId = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataBasic", x => x.id);
                    table.ForeignKey(
                        name: "FK_dataBasic_eps_epsId",
                        column: x => x.epsId,
                        principalSchema: "parameters",
                        principalTable: "eps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dataBasic_materialStatus_materialStatusId",
                        column: x => x.materialStatusId,
                        principalSchema: "parameters",
                        principalTable: "materialStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dataBasic_munisipality_munisipalityId",
                        column: x => x.munisipalityId,
                        principalSchema: "parameters",
                        principalTable: "munisipality",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dataBasic_person_personaId",
                        column: x => x.personaId,
                        principalSchema: "security",
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dataBasic_rh_rhId",
                        column: x => x.rhId,
                        principalSchema: "parameters",
                        principalTable: "rh",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.id);
                    table.ForeignKey(
                        name: "fk_teacher_person",
                        column: x => x.person_id,
                        principalSchema: "security",
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    photo = table.Column<string>(type: "text", unicode: false, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    twostep = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_person_person_id",
                        column: x => x.person_id,
                        principalSchema: "security",
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agenda_day",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    group_id = table.Column<int>(type: "integer", nullable: false),
                    agenda_id = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    opened_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    closed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agenda_day", x => x.id);
                    table.ForeignKey(
                        name: "fk_agenda_day_agenda",
                        column: x => x.agenda_id,
                        principalSchema: "business",
                        principalTable: "agenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_agenda_day_group",
                        column: x => x.group_id,
                        principalSchema: "business",
                        principalTable: "group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    group_id = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                    table.ForeignKey(
                        name: "FK_student_group_group_id",
                        column: x => x.group_id,
                        principalSchema: "business",
                        principalTable: "group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_student_person_person_id",
                        column: x => x.person_id,
                        principalSchema: "security",
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "composition_agenda_question",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    agenda_id = table.Column<int>(type: "integer", nullable: false),
                    question_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_composition_agenda_question", x => x.id);
                    table.ForeignKey(
                        name: "fk_caq_agenda",
                        column: x => x.agenda_id,
                        principalSchema: "business",
                        principalTable: "agenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_caq_question",
                        column: x => x.question_id,
                        principalSchema: "business",
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "question_option",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question_id = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_option", x => x.id);
                    table.ForeignKey(
                        name: "FK_question_option_question_question_id",
                        column: x => x.question_id,
                        principalSchema: "business",
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academic_load",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    teacher_id = table.Column<int>(type: "integer", nullable: false),
                    subject_id = table.Column<int>(type: "integer", nullable: false),
                    group_id = table.Column<int>(type: "integer", nullable: false),
                    days = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academic_load", x => x.id);
                    table.ForeignKey(
                        name: "fk_academic_load_group",
                        column: x => x.group_id,
                        principalSchema: "business",
                        principalTable: "group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_academic_load_subject",
                        column: x => x.subject_id,
                        principalSchema: "parameters",
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_academic_load_teacher",
                        column: x => x.teacher_id,
                        principalSchema: "business",
                        principalTable: "teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "group_director",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    teacher_id = table.Column<int>(type: "integer", nullable: false),
                    group_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_director", x => x.id);
                    table.ForeignKey(
                        name: "fk_group_director_group",
                        column: x => x.group_id,
                        principalSchema: "business",
                        principalTable: "group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_group_director_teacher",
                        column: x => x.teacher_id,
                        principalSchema: "business",
                        principalTable: "teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userRol",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    rol_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => x.id);
                    table.ForeignKey(
                        name: "FK_userRol_rol_rol_id",
                        column: x => x.rol_id,
                        principalSchema: "security",
                        principalTable: "rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userRol_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "security",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agenda_day_student",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    agenda_day_id = table.Column<int>(type: "integer", nullable: false),
                    student_id = table.Column<int>(type: "integer", nullable: false),
                    agenda_day_student_status = table.Column<int>(type: "integer", nullable: false),
                    completed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agenda_day_student", x => x.id);
                    table.ForeignKey(
                        name: "fk_ads_agenda_day",
                        column: x => x.agenda_day_id,
                        principalSchema: "business",
                        principalTable: "agenda_day",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ads_students",
                        column: x => x.student_id,
                        principalSchema: "business",
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attendants",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    student_id = table.Column<int>(type: "integer", nullable: true),
                    relationship_type = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendants", x => x.id);
                    table.ForeignKey(
                        name: "fk_attendants_person",
                        column: x => x.person_id,
                        principalSchema: "security",
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_attendants_student",
                        column: x => x.student_id,
                        principalSchema: "business",
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tutition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    GradeId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutition_grade_GradeId",
                        column: x => x.GradeId,
                        principalSchema: "parameters",
                        principalTable: "grade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tutition_student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "business",
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_answer",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    agenda_day_student_id = table.Column<int>(type: "integer", nullable: false),
                    question_id = table.Column<int>(type: "integer", nullable: false),
                    value_text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    value_bool = table.Column<bool>(type: "boolean", nullable: true),
                    value_number = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    value_date = table.Column<DateTime>(type: "date", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_answer", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_answer_ads",
                        column: x => x.agenda_day_student_id,
                        principalSchema: "business",
                        principalTable: "agenda_day_student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_answer_question",
                        column: x => x.question_id,
                        principalSchema: "business",
                        principalTable: "question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "teacher_observation",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    teacher_id = table.Column<int>(type: "integer", nullable: false),
                    agenda_day_student_id = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    academic_load_id = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_observation", x => x.id);
                    table.ForeignKey(
                        name: "fk_to_agenda_day_student",
                        column: x => x.agenda_day_student_id,
                        principalSchema: "business",
                        principalTable: "agenda_day_student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_to_teacher",
                        column: x => x.teacher_id,
                        principalSchema: "business",
                        principalTable: "teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_to_teacher_acadmic_observation",
                        column: x => x.academic_load_id,
                        principalSchema: "business",
                        principalTable: "academic_load",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student_answer_option",
                schema: "business",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    student_answer_id = table.Column<int>(type: "integer", nullable: false),
                    question_option_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_answer_option", x => x.id);
                    table.ForeignKey(
                        name: "fk_sao_question_option",
                        column: x => x.question_option_id,
                        principalSchema: "business",
                        principalTable: "question_option",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sao_student_answer",
                        column: x => x.student_answer_id,
                        principalSchema: "business",
                        principalTable: "student_answer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "parameters",
                table: "departamet",
                columns: new[] { "id", "created_at", "deleted_at", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, "Amazonas", 1, null },
                    { 2, null, null, "Antioquia", 1, null },
                    { 3, null, null, "Arauca", 1, null },
                    { 4, null, null, "Atlántico", 1, null },
                    { 5, null, null, "Bolívar", 1, null },
                    { 6, null, null, "Boyacá", 1, null },
                    { 7, null, null, "Caldas", 1, null },
                    { 8, null, null, "Caquetá", 1, null },
                    { 9, null, null, "Casanare", 1, null },
                    { 10, null, null, "Cauca", 1, null },
                    { 11, null, null, "Cesar", 1, null },
                    { 12, null, null, "Chocó", 1, null },
                    { 13, null, null, "Córdoba", 1, null },
                    { 14, null, null, "Cundinamarca", 1, null },
                    { 15, null, null, "Guainía", 1, null },
                    { 16, null, null, "Guaviare", 1, null },
                    { 17, null, null, "Huila", 1, null },
                    { 18, null, null, "La Guajira", 1, null },
                    { 19, null, null, "Magdalena", 1, null },
                    { 20, null, null, "Meta", 1, null },
                    { 21, null, null, "Nariño", 1, null },
                    { 22, null, null, "Norte de Santander", 1, null },
                    { 23, null, null, "Putumayo", 1, null },
                    { 24, null, null, "Quindío", 1, null },
                    { 25, null, null, "Risaralda", 1, null },
                    { 26, null, null, "San Andrés y Providencia", 1, null },
                    { 27, null, null, "Santander", 1, null },
                    { 28, null, null, "Sucre", 1, null },
                    { 29, null, null, "Tolima", 1, null },
                    { 30, null, null, "Valle del Cauca", 1, null },
                    { 31, null, null, "Vaupés", 1, null },
                    { 32, null, null, "Vichada", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "parameters",
                table: "documentType",
                columns: new[] { "id", "Acronym", "created_at", "deleted_at", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, "C.C", null, null, "Cedula Ciudadana", 1, null },
                    { 2, "T.I", null, null, "Targeta de identidad", 1, null },
                    { 3, "R.C", null, null, "Registro civil", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "parameters",
                table: "eps",
                columns: new[] { "id", "created_at", "deleted_at", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, "Nueva eps", 1, null },
                    { 2, null, null, "Sanitas", 1, null },
                    { 3, null, null, "Coperacion indigena", 1, null },
                    { 4, null, null, "Estocolmo", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "form",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "order", "path", "status", "updated_at" },
                values: new object[,]
                {
                    { 3, null, null, "Gestión de docentes", "Docentes", 3, "docentes", 1, null },
                    { 4, null, null, "Gestión de estudiantes", "Niños", 4, "ninos", 1, null },
                    { 5, null, null, "Gestión de acudientes", "Acudientes", 5, "acudientes", 1, null },
                    { 6, null, null, "Gestión de aulas", "Matricula", 1, "aulas", 1, null },
                    { 7, null, null, "Gestión de agrupaciones", "Agrupación", 2, "agrupación", 1, null },
                    { 8, null, null, "Asignación de directores de grupo", "Director de Grupo", 3, "directorGrupo", 1, null },
                    { 9, null, null, "Gestión de carga académica", "Carga Académica", 4, "cargaAcademica", 1, null },
                    { 10, null, null, "Creacion de preguntas globales", "Preguntas", 1, "composicion", 1, null },
                    { 11, null, null, "Gestión de agendas", "Agendas", 2, "agendas", 1, null },
                    { 13, null, null, "Gestión de grados", "Grados", 1, "grados", 1, null },
                    { 14, null, null, "Gestión de grupos", "Grupos", 2, "grupos", 1, null },
                    { 16, null, null, "Gestión de EPS", "EPS", 4, "eps", 1, null },
                    { 19, null, null, "Gestión de roles de usuario", "Roles", 1, "roles", 1, null },
                    { 20, null, null, "Gestión de permisos", "Permisos", 2, "permisos", 1, null },
                    { 21, null, null, "Gestión de módulos", "Módulos", 3, "modulos", 1, null },
                    { 22, null, null, "Gestión de formularios", "Formularios", 4, "formularios", 1, null },
                    { 23, null, null, "Asignación de roles a usuarios", "Asignación Roles", 5, "asignacionRoles", 1, null },
                    { 24, null, null, "Asignación de módulos a roles", "Asignación Módulos", 6, "asiganacionModulos", 1, null },
                    { 25, null, null, "Asignación de permisos a roles", "Asignación de Permisos", 7, "asignacionPermisos", 1, null },
                    { 26, null, null, "Gestión de usuarios", "Usuarios", 8, "usuarios", 1, null },
                    { 27, null, null, "Informacion estadisticas del sistema", "Panel", 1, "panel", 1, null },
                    { 28, null, null, "Gestión de carga académica", "Carga Académica", 1, "mihorario", 1, null },
                    { 29, null, null, "Gestion de agenda diaria", "Registro de agenda", 1, "dashagenda", 1, null },
                    { 30, null, null, "Gestion de observaciones diaria", "Observaciones", 2, "observacion", 1, null },
                    { 31, null, null, "Agenda de los niños vinculados", "Agendas vinculadas", 1, "confirmacionagenda", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "parameters",
                table: "grade",
                columns: new[] { "id", "created_at", "deleted_at", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, "Primero", 1, null },
                    { 2, null, null, "Segundo", 1, null },
                    { 3, null, null, "Tercero", 1, null },
                    { 4, null, null, "Cuarto", 1, null },
                    { 5, null, null, "Quinto", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "parameters",
                table: "materialStatus",
                columns: new[] { "id", "created_at", "deleted_at", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, "Casado", 1, null },
                    { 2, null, null, "Soltero", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "module",
                columns: new[] { "id", "created_at", "deleted_at", "description", "icon", "name", "order", "path", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, "Pantalla principal del sistema", "home", "Inicio", 1, "/dashboard", 1, null },
                    { 2, null, null, "Opciones administrativas del sistema", "person", "Administración", 2, "", 1, null },
                    { 3, null, null, "Módulo para gestión académica", "school", "Académico", 3, "", 1, null },
                    { 4, null, null, "Gestión de eventos y agendas", "book", "Agenda", 4, "", 1, null },
                    { 5, null, null, "Parámetros y ajustes del sistema", "settings", "Configuración", 5, "", 1, null },
                    { 6, null, null, "Todo el tema de permisos del sistema", "security", "Seguridad", 6, "", 1, null },
                    { 7, null, null, "Infomracion generada por el sistema", "bar_chart", "Reportes", 7, "", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "permission",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, "Formulario de inicio", "Todo", 1, null },
                    { 2, null, null, "Todos los permisos excepto eliminar persistentemente", "Editor", 1, null },
                    { 3, null, null, "Solo puede ver", "Lectura", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "parameters",
                table: "rh",
                columns: new[] { "id", "created_at", "deleted_at", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, "O+", 1, null },
                    { 2, null, null, "O-", 1, null },
                    { 3, null, null, "A+", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "rol",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, "Control sobre todo", "Administrador", 1, null },
                    { 2, null, null, "Permisos al 90%", "Administrativo", 1, null },
                    { 3, null, null, "Permisos al 30%", "Docente", 1, null },
                    { 4, null, null, "Solo interactura de forma base", "Acudiente", 1, null },
                    { 5, null, null, "Docente que tiene a cargo un grado como su representante", "Docente director", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "parameters",
                table: "subject",
                columns: new[] { "id", "created_at", "deleted_at", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, "Lengua Castellana", 1, null },
                    { 2, null, null, "Matemáticas", 1, null },
                    { 3, null, null, "Ciencias Naturales", 1, null },
                    { 4, null, null, "Ciencias Sociales", 1, null },
                    { 5, null, null, "Inglés", 1, null },
                    { 6, null, null, "Educación Artística", 1, null },
                    { 7, null, null, "Educación Física", 1, null },
                    { 8, null, null, "Tecnología e Informática", 1, null },
                    { 9, null, null, "Ética y Valores", 1, null },
                    { 10, null, null, "Religión", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "parameters",
                table: "type_answare",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, "Respuesta de texto libre", "Text", 1, null },
                    { 2, null, null, "Sí / No", "Bool", 1, null },
                    { 3, null, null, "Numérica", "Number", 1, null },
                    { 4, null, null, "Fecha", "Date", 1, null },
                    { 5, null, null, "Selección de opción única", "OptionSingle", 1, null },
                    { 6, null, null, "Selección de opción múltiple", "OptionMulti", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "business",
                table: "group",
                columns: new[] { "id", "agenda_id", "amount_students", "created_at", "deleted_at", "grade_id", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, 20, null, null, 1, "Primero A", 1, null },
                    { 3, null, 20, null, null, 1, "Primero B", 1, null },
                    { 4, null, 20, null, null, 1, "Primero C", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "moduleForm",
                columns: new[] { "id", "created_at", "deleted_at", "form_id", "module_id", "status", "updated_at" },
                values: new object[,]
                {
                    { 3, null, null, 3, 2, 1, null },
                    { 4, null, null, 4, 2, 1, null },
                    { 5, null, null, 5, 2, 1, null },
                    { 6, null, null, 6, 3, 1, null },
                    { 7, null, null, 7, 3, 1, null },
                    { 8, null, null, 8, 3, 1, null },
                    { 9, null, null, 9, 3, 1, null },
                    { 10, null, null, 10, 4, 1, null },
                    { 11, null, null, 11, 4, 1, null },
                    { 13, null, null, 13, 5, 1, null },
                    { 14, null, null, 14, 5, 1, null },
                    { 16, null, null, 16, 5, 1, null },
                    { 19, null, null, 19, 6, 1, null },
                    { 20, null, null, 20, 6, 1, null },
                    { 21, null, null, 21, 6, 1, null },
                    { 22, null, null, 22, 6, 1, null },
                    { 23, null, null, 23, 6, 1, null },
                    { 24, null, null, 24, 6, 1, null },
                    { 25, null, null, 25, 6, 1, null },
                    { 26, null, null, 26, 6, 1, null },
                    { 27, null, null, 27, 7, 1, null },
                    { 28, null, null, 28, 3, 1, null },
                    { 29, null, null, 29, 4, 1, null },
                    { 30, null, null, 30, 4, 1, null },
                    { 31, null, null, 31, 4, 1, null }
                });

            migrationBuilder.InsertData(
                schema: "parameters",
                table: "munisipality",
                columns: new[] { "id", "created_at", "deleted_at", "departametId", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, 1, "Leticia", 1, null },
                    { 2, null, null, 1, "Puerto Nariño", 1, null },
                    { 3, null, null, 1, "Tarapacá", 1, null },
                    { 4, null, null, 1, "La Pedrera", 1, null },
                    { 5, null, null, 1, "El Encanto", 1, null },
                    { 6, null, null, 2, "Medellín", 1, null },
                    { 7, null, null, 2, "Bello", 1, null },
                    { 8, null, null, 2, "Envigado", 1, null },
                    { 9, null, null, 2, "Itagüí", 1, null },
                    { 10, null, null, 2, "Rionegro", 1, null },
                    { 11, null, null, 3, "Arauca", 1, null },
                    { 12, null, null, 3, "Saravena", 1, null },
                    { 13, null, null, 3, "Tame", 1, null },
                    { 14, null, null, 3, "Fortul", 1, null },
                    { 15, null, null, 3, "Arauquita", 1, null },
                    { 16, null, null, 4, "Barranquilla", 1, null },
                    { 17, null, null, 4, "Soledad", 1, null },
                    { 18, null, null, 4, "Malambo", 1, null },
                    { 19, null, null, 4, "Sabanalarga", 1, null },
                    { 20, null, null, 4, "Galapa", 1, null },
                    { 21, null, null, 5, "Cartagena de Indias", 1, null },
                    { 22, null, null, 5, "Magangué", 1, null },
                    { 23, null, null, 5, "Turbaco", 1, null },
                    { 24, null, null, 5, "Arjona", 1, null },
                    { 25, null, null, 5, "El Carmen de Bolívar", 1, null },
                    { 26, null, null, 6, "Tunja", 1, null },
                    { 27, null, null, 6, "Duitama", 1, null },
                    { 28, null, null, 6, "Sogamoso", 1, null },
                    { 29, null, null, 6, "Chiquinquirá", 1, null },
                    { 30, null, null, 6, "Paipa", 1, null },
                    { 31, null, null, 7, "Manizales", 1, null },
                    { 32, null, null, 7, "Villamaría", 1, null },
                    { 33, null, null, 7, "Chinchiná", 1, null },
                    { 34, null, null, 7, "La Dorada", 1, null },
                    { 35, null, null, 7, "Riosucio", 1, null },
                    { 36, null, null, 8, "Florencia", 1, null },
                    { 37, null, null, 8, "San Vicente del Caguán", 1, null },
                    { 38, null, null, 8, "Puerto Rico", 1, null },
                    { 39, null, null, 8, "Cartagena del Chairá", 1, null },
                    { 40, null, null, 8, "El Doncello", 1, null },
                    { 41, null, null, 9, "Yopal", 1, null },
                    { 42, null, null, 9, "Aguazul", 1, null },
                    { 43, null, null, 9, "Villanueva", 1, null },
                    { 44, null, null, 9, "Monterrey", 1, null },
                    { 45, null, null, 9, "Tauramena", 1, null },
                    { 46, null, null, 10, "Popayán", 1, null },
                    { 47, null, null, 10, "Santander de Quilichao", 1, null },
                    { 48, null, null, 10, "Puerto Tejada", 1, null },
                    { 49, null, null, 10, "Patía (El Bordo)", 1, null },
                    { 50, null, null, 10, "Guapi", 1, null },
                    { 51, null, null, 11, "Valledupar", 1, null },
                    { 52, null, null, 11, "Aguachica", 1, null },
                    { 53, null, null, 11, "Bosconia", 1, null },
                    { 54, null, null, 11, "Curumaní", 1, null },
                    { 55, null, null, 11, "Chimichagua", 1, null },
                    { 56, null, null, 12, "Quibdó", 1, null },
                    { 57, null, null, 12, "Istmina", 1, null },
                    { 58, null, null, 12, "Tadó", 1, null },
                    { 59, null, null, 12, "Condoto", 1, null },
                    { 60, null, null, 12, "Bahía Solano", 1, null },
                    { 61, null, null, 13, "Montería", 1, null },
                    { 62, null, null, 13, "Cereté", 1, null },
                    { 63, null, null, 13, "Sahagún", 1, null },
                    { 64, null, null, 13, "Lorica", 1, null },
                    { 65, null, null, 13, "Planeta Rica", 1, null },
                    { 66, null, null, 14, "Bogotá D.C.", 1, null },
                    { 67, null, null, 14, "Soacha", 1, null },
                    { 68, null, null, 14, "Facatativá", 1, null },
                    { 69, null, null, 14, "Zipaquirá", 1, null },
                    { 70, null, null, 14, "Girardot", 1, null },
                    { 71, null, null, 15, "Inírida", 1, null },
                    { 72, null, null, 15, "Barranco Minas", 1, null },
                    { 73, null, null, 15, "San Felipe", 1, null },
                    { 74, null, null, 15, "Puerto Colombia", 1, null },
                    { 75, null, null, 15, "La Guadalupe", 1, null },
                    { 76, null, null, 16, "San José del Guaviare", 1, null },
                    { 77, null, null, 16, "Calamar", 1, null },
                    { 78, null, null, 16, "Miraflores", 1, null },
                    { 79, null, null, 16, "El Retorno", 1, null },
                    { 80, null, null, 16, "La Libertad", 1, null },
                    { 81, null, null, 18, "Riohacha", 1, null },
                    { 82, null, null, 18, "Maicao", 1, null },
                    { 83, null, null, 18, "Uribia", 1, null },
                    { 84, null, null, 18, "Fonseca", 1, null },
                    { 85, null, null, 18, "Manaure", 1, null },
                    { 86, null, null, 19, "Santa Marta", 1, null },
                    { 87, null, null, 19, "Ciénaga", 1, null },
                    { 88, null, null, 19, "Fundación", 1, null },
                    { 89, null, null, 19, "Plato", 1, null },
                    { 90, null, null, 19, "Pivijay", 1, null },
                    { 91, null, null, 20, "Villavicencio", 1, null },
                    { 92, null, null, 20, "Acacías", 1, null },
                    { 93, null, null, 20, "Granada", 1, null },
                    { 94, null, null, 20, "Puerto López", 1, null },
                    { 95, null, null, 20, "Cumaral", 1, null },
                    { 96, null, null, 21, "Pasto", 1, null },
                    { 97, null, null, 21, "Ipiales", 1, null },
                    { 98, null, null, 21, "Tumaco", 1, null },
                    { 99, null, null, 21, "Túquerres", 1, null },
                    { 100, null, null, 21, "La Unión", 1, null },
                    { 101, null, null, 22, "Cúcuta", 1, null },
                    { 102, null, null, 22, "Ocaña", 1, null },
                    { 103, null, null, 22, "Pamplona", 1, null },
                    { 104, null, null, 22, "Villa del Rosario", 1, null },
                    { 105, null, null, 22, "Los Patios", 1, null },
                    { 106, null, null, 23, "Mocoa", 1, null },
                    { 107, null, null, 23, "Puerto Asís", 1, null },
                    { 108, null, null, 23, "Orito", 1, null },
                    { 109, null, null, 23, "Villagarzón", 1, null },
                    { 110, null, null, 23, "Sibundoy", 1, null },
                    { 111, null, null, 24, "Armenia", 1, null },
                    { 112, null, null, 24, "Calarcá", 1, null },
                    { 113, null, null, 24, "La Tebaida", 1, null },
                    { 114, null, null, 24, "Montenegro", 1, null },
                    { 115, null, null, 24, "Quimbaya", 1, null },
                    { 116, null, null, 25, "Pereira", 1, null },
                    { 117, null, null, 25, "Dosquebradas", 1, null },
                    { 118, null, null, 25, "Santa Rosa de Cabal", 1, null },
                    { 119, null, null, 25, "La Virginia", 1, null },
                    { 120, null, null, 25, "Marsella", 1, null },
                    { 121, null, null, 26, "San Andrés", 1, null },
                    { 122, null, null, 26, "Providencia", 1, null },
                    { 123, null, null, 26, "Santa Catalina", 1, null },
                    { 124, null, null, 26, "Cove Sea Side", 1, null },
                    { 125, null, null, 26, "La Loma", 1, null },
                    { 126, null, null, 27, "Bucaramanga", 1, null },
                    { 127, null, null, 27, "Floridablanca", 1, null },
                    { 128, null, null, 27, "Girón", 1, null },
                    { 129, null, null, 27, "Piedecuesta", 1, null },
                    { 130, null, null, 27, "Barrancabermeja", 1, null },
                    { 131, null, null, 28, "Sincelejo", 1, null },
                    { 132, null, null, 28, "Corozal", 1, null },
                    { 133, null, null, 28, "Sampués", 1, null },
                    { 134, null, null, 28, "San Marcos", 1, null },
                    { 135, null, null, 28, "Tolú", 1, null },
                    { 136, null, null, 29, "Ibagué", 1, null },
                    { 137, null, null, 29, "Espinal", 1, null },
                    { 138, null, null, 29, "Melgar", 1, null },
                    { 139, null, null, 29, "Honda", 1, null },
                    { 140, null, null, 29, "Líbano", 1, null },
                    { 141, null, null, 30, "Cali", 1, null },
                    { 142, null, null, 30, "Palmira", 1, null },
                    { 143, null, null, 30, "Buenaventura", 1, null },
                    { 144, null, null, 30, "Tuluá", 1, null },
                    { 145, null, null, 30, "Buga", 1, null },
                    { 146, null, null, 31, "Mitú", 1, null },
                    { 147, null, null, 31, "Carurú", 1, null },
                    { 148, null, null, 31, "Pacoa", 1, null },
                    { 149, null, null, 31, "Taraira", 1, null },
                    { 150, null, null, 31, "Yavaraté", 1, null },
                    { 151, null, null, 32, "Puerto Carreño", 1, null },
                    { 152, null, null, 32, "La Primavera", 1, null },
                    { 153, null, null, 32, "Santa Rosalía", 1, null },
                    { 154, null, null, 32, "Cumaribo", 1, null },
                    { 155, null, null, 32, "Guarrojo", 1, null },
                    { 200, null, null, 17, "Neiva", 1, null },
                    { 201, null, null, 17, "Acevedo", 1, null },
                    { 202, null, null, 17, "Agrado", 1, null },
                    { 203, null, null, 17, "Aipe", 1, null },
                    { 204, null, null, 17, "Algeciras", 1, null },
                    { 205, null, null, 17, "Altamira", 1, null },
                    { 206, null, null, 17, "Baraya", 1, null },
                    { 207, null, null, 17, "Campoalegre", 1, null },
                    { 208, null, null, 17, "Colombia", 1, null },
                    { 209, null, null, 17, "Elías", 1, null },
                    { 210, null, null, 17, "Garzón", 1, null },
                    { 211, null, null, 17, "Gigante", 1, null },
                    { 212, null, null, 17, "Guadalupe", 1, null },
                    { 213, null, null, 17, "Hobo", 1, null },
                    { 214, null, null, 17, "Íquira", 1, null },
                    { 215, null, null, 17, "Isnos", 1, null },
                    { 216, null, null, 17, "La Argentina", 1, null },
                    { 217, null, null, 17, "La Plata", 1, null },
                    { 218, null, null, 17, "Nátaga", 1, null },
                    { 219, null, null, 17, "Oporapa", 1, null },
                    { 220, null, null, 17, "Paicol", 1, null },
                    { 221, null, null, 17, "Palermo", 1, null },
                    { 222, null, null, 17, "Palestina", 1, null },
                    { 223, null, null, 17, "Pital", 1, null },
                    { 224, null, null, 17, "Pitalito", 1, null },
                    { 225, null, null, 17, "Rivera", 1, null },
                    { 226, null, null, 17, "Saladoblanco", 1, null },
                    { 227, null, null, 17, "San Agustín", 1, null },
                    { 228, null, null, 17, "Santa María", 1, null },
                    { 229, null, null, 17, "Suaza", 1, null },
                    { 230, null, null, 17, "Tarqui", 1, null },
                    { 231, null, null, 17, "Tello", 1, null },
                    { 232, null, null, 17, "Teruel", 1, null },
                    { 233, null, null, 17, "Tesalia", 1, null },
                    { 234, null, null, 17, "Timaná", 1, null },
                    { 235, null, null, 17, "Villavieja", 1, null },
                    { 236, null, null, 17, "Yaguará", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "person",
                columns: new[] { "id", "age", "created_at", "deleted_at", "DocumentTypeId", "fisrtName", "gender", "identification", "lastName", "phone", "secondLastName", "secondName", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, 32, null, null, 1, "Carlos", 0, 100200300L, "Pérez", 300123456L, "García", "Andrés", 1, null },
                    { 2, 25, null, null, 2, "María", 1, 500600700L, "López", 310987654L, "Martínez", "Fernanda", 1, null },
                    { 3, 18, null, null, 3, "Juan", 0, 800900100L, "Rodríguez", 320456789L, "Hernández", "Camilo", 1, null },
                    { 4, 29, null, null, 1, "Laura", 1, 111222333L, "Moreno", 301654987L, "Castro", "Isabel", 3, null },
                    { 5, 21, null, null, 2, "Santiago", 2, 444555666L, "Ramírez", 312789654L, "Torres", "Esteban", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "rolFormPermission",
                columns: new[] { "id", "created_at", "deleted_at", "form_id", "permission_id", "rol_id", "status", "updated_at" },
                values: new object[,]
                {
                    { 3, null, null, 3, 1, 1, 1, null },
                    { 4, null, null, 4, 1, 1, 1, null },
                    { 5, null, null, 5, 1, 1, 1, null },
                    { 6, null, null, 6, 1, 1, 1, null },
                    { 7, null, null, 7, 1, 1, 1, null },
                    { 8, null, null, 8, 1, 1, 1, null },
                    { 9, null, null, 9, 1, 1, 1, null },
                    { 10, null, null, 10, 1, 1, 1, null },
                    { 11, null, null, 11, 1, 1, 1, null },
                    { 13, null, null, 13, 1, 1, 1, null },
                    { 14, null, null, 14, 1, 1, 1, null },
                    { 19, null, null, 19, 1, 1, 1, null },
                    { 20, null, null, 20, 1, 1, 1, null },
                    { 21, null, null, 21, 1, 1, 1, null },
                    { 22, null, null, 22, 1, 1, 1, null },
                    { 23, null, null, 23, 1, 1, 1, null },
                    { 24, null, null, 24, 1, 1, 1, null },
                    { 25, null, null, 25, 1, 1, 1, null },
                    { 26, null, null, 26, 1, 1, 1, null },
                    { 27, null, null, 27, 1, 1, 1, null },
                    { 29, null, null, 28, 1, 5, 1, null },
                    { 30, null, null, 29, 1, 5, 1, null },
                    { 31, null, null, 30, 1, 5, 1, null },
                    { 32, null, null, 28, 1, 3, 1, null },
                    { 33, null, null, 30, 1, 3, 1, null },
                    { 34, null, null, 31, 1, 4, 1, null }
                });

            migrationBuilder.InsertData(
                schema: "business",
                table: "dataBasic",
                columns: new[] { "id", "adress", "birthDate", "created_at", "deleted_at", "epsId", "materialStatusId", "munisipalityId", "personaId", "rhId", "status", "stratumStatus", "updated_at" },
                values: new object[,]
                {
                    { 1, "Calle 10 #15-20", new DateTime(1993, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 1, 200, 1, 1, 1, 3, null },
                    { 2, "Carrera 25 #8-30", new DateTime(2000, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 2, 200, 2, 2, 1, 4, null },
                    { 3, "Diagonal 45 #20-15", new DateTime(1993, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 2, 200, 3, 3, 1, 2, null },
                    { 4, "Avenida 7 #12-45", new DateTime(1993, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 1, 200, 4, 1, 1, 5, null },
                    { 5, "Calle 50 #25-18", new DateTime(1993, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 2, 200, 5, 2, 1, 3, null }
                });

            migrationBuilder.InsertData(
                schema: "business",
                table: "student",
                columns: new[] { "id", "created_at", "deleted_at", "group_id", "person_id", "status", "updated_at" },
                values: new object[] { 1, null, null, null, 3, 1, null });

            migrationBuilder.InsertData(
                schema: "business",
                table: "teacher",
                columns: new[] { "id", "created_at", "deleted_at", "person_id", "status", "updated_at" },
                values: new object[] { 1, null, null, 2, 1, null });

            migrationBuilder.InsertData(
                schema: "security",
                table: "users",
                columns: new[] { "id", "created_at", "deleted_at", "email", "password", "person_id", "photo", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, null, "ejemplo1@gmail.com", "$2a$11$6LpgqG3XuJ3xbpRp4gcJXeL/pQT79cDv6Vt063Tk5c2klWRpNgR0.", 1, "./icons/default.png", 1, null },
                    { 2, null, null, "ejemplo2@gmail.com", "$2a$11$6LpgqG3XuJ3xbpRp4gcJXeL/pQT79cDv6Vt063Tk5c2klWRpNgR0.", 2, "./icons/default.png", 1, null },
                    { 3, null, null, "ejemplo3@gmail.com", "$2a$11$6LpgqG3XuJ3xbpRp4gcJXeL/pQT79cDv6Vt063Tk5c2klWRpNgR0.", 3, "./icons/default.png", 1, null },
                    { 4, null, null, "ejemplo4@gmail.com", "$2a$11$6LpgqG3XuJ3xbpRp4gcJXeL/pQT79cDv6Vt063Tk5c2klWRpNgR0.", 4, "./icons/default.png", 1, null },
                    { 5, null, null, "ejemplo5@gmail.com", "$2a$11$6LpgqG3XuJ3xbpRp4gcJXeL/pQT79cDv6Vt063Tk5c2klWRpNgR0.", 5, "./icons/default.png", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "userRol",
                columns: new[] { "id", "created_at", "deleted_at", "rol_id", "status", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, null, null, 1, 1, null, 1 },
                    { 2, null, null, 3, 1, null, 2 },
                    { 3, null, null, 3, 1, null, 3 },
                    { 4, null, null, 4, 1, null, 4 },
                    { 5, null, null, 4, 1, null, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_academic_load_group_id",
                schema: "business",
                table: "academic_load",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_academic_load_subject_id",
                schema: "business",
                table: "academic_load",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "uq_academic_load_slot",
                schema: "business",
                table: "academic_load",
                columns: new[] { "teacher_id", "group_id", "subject_id", "days" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_agenda_name",
                schema: "business",
                table: "agenda",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_agenda_day_agenda_id",
                schema: "business",
                table: "agenda_day",
                column: "agenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_agenda_day_group_date",
                schema: "business",
                table: "agenda_day",
                columns: new[] { "group_id", "date" });

            migrationBuilder.CreateIndex(
                name: "uq_agenda_day_group_agenda_date",
                schema: "business",
                table: "agenda_day",
                columns: new[] { "group_id", "agenda_id", "date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_agenda_day_student_student_id",
                schema: "business",
                table: "agenda_day_student",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "uq_ads_agenda_day_student",
                schema: "business",
                table: "agenda_day_student",
                columns: new[] { "agenda_day_id", "student_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_attendants_person_id",
                schema: "business",
                table: "attendants",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "uq_attendants_student_person",
                schema: "business",
                table: "attendants",
                columns: new[] { "student_id", "person_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_composition_agenda_question_question_id",
                schema: "business",
                table: "composition_agenda_question",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "uq_comp_agenda_question",
                schema: "business",
                table: "composition_agenda_question",
                columns: new[] { "agenda_id", "question_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dataBasic_epsId",
                schema: "business",
                table: "dataBasic",
                column: "epsId");

            migrationBuilder.CreateIndex(
                name: "IX_dataBasic_materialStatusId",
                schema: "business",
                table: "dataBasic",
                column: "materialStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_dataBasic_munisipalityId",
                schema: "business",
                table: "dataBasic",
                column: "munisipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_dataBasic_personaId",
                schema: "business",
                table: "dataBasic",
                column: "personaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dataBasic_rhId",
                schema: "business",
                table: "dataBasic",
                column: "rhId");

            migrationBuilder.CreateIndex(
                name: "IX_group_agenda_id",
                schema: "business",
                table: "group",
                column: "agenda_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_grade_id",
                schema: "business",
                table: "group",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "uq_group_name_grade",
                schema: "business",
                table: "group",
                columns: new[] { "name", "grade_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_group_director_group_id",
                schema: "business",
                table: "group_director",
                column: "group_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_group_director_teacher_id",
                schema: "business",
                table: "group_director",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_moduleForm_form_id",
                schema: "security",
                table: "moduleForm",
                column: "form_id");

            migrationBuilder.CreateIndex(
                name: "IX_moduleForm_module_id",
                schema: "security",
                table: "moduleForm",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_munisipality_departametId",
                schema: "parameters",
                table: "munisipality",
                column: "departametId");

            migrationBuilder.CreateIndex(
                name: "IX_person_DocumentTypeId",
                schema: "security",
                table: "person",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_person_identification",
                schema: "security",
                table: "person",
                column: "identification",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_question_type_answer_id",
                schema: "business",
                table: "question",
                column: "type_answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_question_option_question_id_order",
                schema: "business",
                table: "question_option",
                columns: new[] { "question_id", "order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rolFormPermission_form_id",
                schema: "security",
                table: "rolFormPermission",
                column: "form_id");

            migrationBuilder.CreateIndex(
                name: "IX_rolFormPermission_permission_id",
                schema: "security",
                table: "rolFormPermission",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_rolFormPermission_rol_id",
                schema: "security",
                table: "rolFormPermission",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_group_id",
                schema: "business",
                table: "student",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_person_id",
                schema: "business",
                table: "student",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_answer_question_id",
                schema: "business",
                table: "student_answer",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "uq_student_answer_ads_question",
                schema: "business",
                table: "student_answer",
                columns: new[] { "agenda_day_student_id", "question_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_student_answer_option_question_option_id",
                schema: "business",
                table: "student_answer_option",
                column: "question_option_id");

            migrationBuilder.CreateIndex(
                name: "uq_sao_answer_option",
                schema: "business",
                table: "student_answer_option",
                columns: new[] { "student_answer_id", "question_option_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_teacher_person",
                schema: "business",
                table: "teacher",
                column: "person_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teacher_observation_academic_load_id",
                schema: "business",
                table: "teacher_observation",
                column: "academic_load_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_observation_agenda_day_student_id",
                schema: "business",
                table: "teacher_observation",
                column: "agenda_day_student_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_observation_teacher_id",
                schema: "business",
                table: "teacher_observation",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tutition_GradeId",
                table: "Tutition",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutition_StudentId",
                table: "Tutition",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_rol_id",
                schema: "security",
                table: "userRol",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_user_id",
                schema: "security",
                table: "userRol",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_person_id",
                schema: "security",
                table: "users",
                column: "person_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_users_email",
                schema: "security",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attendants",
                schema: "business");

            migrationBuilder.DropTable(
                name: "composition_agenda_question",
                schema: "business");

            migrationBuilder.DropTable(
                name: "dataBasic",
                schema: "business");

            migrationBuilder.DropTable(
                name: "group_director",
                schema: "business");

            migrationBuilder.DropTable(
                name: "moduleForm",
                schema: "security");

            migrationBuilder.DropTable(
                name: "rolFormPermission",
                schema: "security");

            migrationBuilder.DropTable(
                name: "student_answer_option",
                schema: "business");

            migrationBuilder.DropTable(
                name: "teacher_observation",
                schema: "business");

            migrationBuilder.DropTable(
                name: "Tutition");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "userRol",
                schema: "security");

            migrationBuilder.DropTable(
                name: "eps",
                schema: "parameters");

            migrationBuilder.DropTable(
                name: "materialStatus",
                schema: "parameters");

            migrationBuilder.DropTable(
                name: "munisipality",
                schema: "parameters");

            migrationBuilder.DropTable(
                name: "rh",
                schema: "parameters");

            migrationBuilder.DropTable(
                name: "module",
                schema: "security");

            migrationBuilder.DropTable(
                name: "form",
                schema: "security");

            migrationBuilder.DropTable(
                name: "permission",
                schema: "security");

            migrationBuilder.DropTable(
                name: "question_option",
                schema: "business");

            migrationBuilder.DropTable(
                name: "student_answer",
                schema: "business");

            migrationBuilder.DropTable(
                name: "academic_load",
                schema: "business");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "rol",
                schema: "security");

            migrationBuilder.DropTable(
                name: "users",
                schema: "security");

            migrationBuilder.DropTable(
                name: "departamet",
                schema: "parameters");

            migrationBuilder.DropTable(
                name: "agenda_day_student",
                schema: "business");

            migrationBuilder.DropTable(
                name: "question",
                schema: "business");

            migrationBuilder.DropTable(
                name: "subject",
                schema: "parameters");

            migrationBuilder.DropTable(
                name: "teacher",
                schema: "business");

            migrationBuilder.DropTable(
                name: "agenda_day",
                schema: "business");

            migrationBuilder.DropTable(
                name: "student",
                schema: "business");

            migrationBuilder.DropTable(
                name: "type_answare",
                schema: "parameters");

            migrationBuilder.DropTable(
                name: "group",
                schema: "business");

            migrationBuilder.DropTable(
                name: "person",
                schema: "security");

            migrationBuilder.DropTable(
                name: "agenda",
                schema: "business");

            migrationBuilder.DropTable(
                name: "grade",
                schema: "parameters");

            migrationBuilder.DropTable(
                name: "documentType",
                schema: "parameters");
        }
    }
}
