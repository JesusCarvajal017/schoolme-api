using Entity.ConfigModels.global;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.ConfigModels.Parameters
{
    public class MunisipalityConfig : IEntityTypeConfiguration<Munisipality>
    {
        public void Configure(EntityTypeBuilder<Munisipality> builder)
        {
            builder.ToTable("munisipality", schema: "parameters");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.DepartamentId)
                .HasColumnName("departametId")
                .IsRequired();

            builder.MapBaseModel();

            // Llave foraena
            builder.HasOne(ur => ur.Departament)
               .WithMany(r => r.Munisipalitys)
               .HasForeignKey(ur => ur.DepartamentId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                // 1. Amazonas
                new Munisipality { Id = 1, Name = "Leticia", DepartamentId = 1 },
                new Munisipality { Id = 2, Name = "Puerto Nariño", DepartamentId = 1 },
                new Munisipality { Id = 3, Name = "Tarapacá", DepartamentId = 1 },
                new Munisipality { Id = 4, Name = "La Pedrera", DepartamentId = 1 },
                new Munisipality { Id = 5, Name = "El Encanto", DepartamentId = 1 },

                // 2. Antioquia
                new Munisipality { Id = 6, Name = "Medellín", DepartamentId = 2 },
                new Munisipality { Id = 7, Name = "Bello", DepartamentId = 2 },
                new Munisipality { Id = 8, Name = "Envigado", DepartamentId = 2 },
                new Munisipality { Id = 9, Name = "Itagüí", DepartamentId = 2 },
                new Munisipality { Id = 10, Name = "Rionegro", DepartamentId = 2 },

                // 3. Arauca
                new Munisipality { Id = 11, Name = "Arauca", DepartamentId = 3 },
                new Munisipality { Id = 12, Name = "Saravena", DepartamentId = 3 },
                new Munisipality { Id = 13, Name = "Tame", DepartamentId = 3 },
                new Munisipality { Id = 14, Name = "Fortul", DepartamentId = 3 },
                new Munisipality { Id = 15, Name = "Arauquita", DepartamentId = 3 },

                // 4. Atlántico
                new Munisipality { Id = 16, Name = "Barranquilla", DepartamentId = 4 },
                new Munisipality { Id = 17, Name = "Soledad", DepartamentId = 4 },
                new Munisipality { Id = 18, Name = "Malambo", DepartamentId = 4 },
                new Munisipality { Id = 19, Name = "Sabanalarga", DepartamentId = 4 },
                new Munisipality { Id = 20, Name = "Galapa", DepartamentId = 4 },

                // 5. Bolívar
                new Munisipality { Id = 21, Name = "Cartagena de Indias", DepartamentId = 5 },
                new Munisipality { Id = 22, Name = "Magangué", DepartamentId = 5 },
                new Munisipality { Id = 23, Name = "Turbaco", DepartamentId = 5 },
                new Munisipality { Id = 24, Name = "Arjona", DepartamentId = 5 },
                new Munisipality { Id = 25, Name = "El Carmen de Bolívar", DepartamentId = 5 },

                // 6. Boyacá
                new Munisipality { Id = 26, Name = "Tunja", DepartamentId = 6 },
                new Munisipality { Id = 27, Name = "Duitama", DepartamentId = 6 },
                new Munisipality { Id = 28, Name = "Sogamoso", DepartamentId = 6 },
                new Munisipality { Id = 29, Name = "Chiquinquirá", DepartamentId = 6 },
                new Munisipality { Id = 30, Name = "Paipa", DepartamentId = 6 },

                // 7. Caldas
                new Munisipality { Id = 31, Name = "Manizales", DepartamentId = 7 },
                new Munisipality { Id = 32, Name = "Villamaría", DepartamentId = 7 },
                new Munisipality { Id = 33, Name = "Chinchiná", DepartamentId = 7 },
                new Munisipality { Id = 34, Name = "La Dorada", DepartamentId = 7 },
                new Munisipality { Id = 35, Name = "Riosucio", DepartamentId = 7 },

                // 8. Caquetá
                new Munisipality { Id = 36, Name = "Florencia", DepartamentId = 8 },
                new Munisipality { Id = 37, Name = "San Vicente del Caguán", DepartamentId = 8 },
                new Munisipality { Id = 38, Name = "Puerto Rico", DepartamentId = 8 },
                new Munisipality { Id = 39, Name = "Cartagena del Chairá", DepartamentId = 8 },
                new Munisipality { Id = 40, Name = "El Doncello", DepartamentId = 8 },

                // 9. Casanare
                new Munisipality { Id = 41, Name = "Yopal", DepartamentId = 9 },
                new Munisipality { Id = 42, Name = "Aguazul", DepartamentId = 9 },
                new Munisipality { Id = 43, Name = "Villanueva", DepartamentId = 9 },
                new Munisipality { Id = 44, Name = "Monterrey", DepartamentId = 9 },
                new Munisipality { Id = 45, Name = "Tauramena", DepartamentId = 9 },

                // 10. Cauca
                new Munisipality { Id = 46, Name = "Popayán", DepartamentId = 10 },
                new Munisipality { Id = 47, Name = "Santander de Quilichao", DepartamentId = 10 },
                new Munisipality { Id = 48, Name = "Puerto Tejada", DepartamentId = 10 },
                new Munisipality { Id = 49, Name = "Patía (El Bordo)", DepartamentId = 10 },
                new Munisipality { Id = 50, Name = "Guapi", DepartamentId = 10 },

                // 11. Cesar
                new Munisipality { Id = 51, Name = "Valledupar", DepartamentId = 11 },
                new Munisipality { Id = 52, Name = "Aguachica", DepartamentId = 11 },
                new Munisipality { Id = 53, Name = "Bosconia", DepartamentId = 11 },
                new Munisipality { Id = 54, Name = "Curumaní", DepartamentId = 11 },
                new Munisipality { Id = 55, Name = "Chimichagua", DepartamentId = 11 },

                // 12. Chocó
                new Munisipality { Id = 56, Name = "Quibdó", DepartamentId = 12 },
                new Munisipality { Id = 57, Name = "Istmina", DepartamentId = 12 },
                new Munisipality { Id = 58, Name = "Tadó", DepartamentId = 12 },
                new Munisipality { Id = 59, Name = "Condoto", DepartamentId = 12 },
                new Munisipality { Id = 60, Name = "Bahía Solano", DepartamentId = 12 },

                // 13. Córdoba
                new Munisipality { Id = 61, Name = "Montería", DepartamentId = 13 },
                new Munisipality { Id = 62, Name = "Cereté", DepartamentId = 13 },
                new Munisipality { Id = 63, Name = "Sahagún", DepartamentId = 13 },
                new Munisipality { Id = 64, Name = "Lorica", DepartamentId = 13 },
                new Munisipality { Id = 65, Name = "Planeta Rica", DepartamentId = 13 },

                // 14. Cundinamarca
                new Munisipality { Id = 66, Name = "Bogotá D.C.", DepartamentId = 14 },
                new Munisipality { Id = 67, Name = "Soacha", DepartamentId = 14 },
                new Munisipality { Id = 68, Name = "Facatativá", DepartamentId = 14 },
                new Munisipality { Id = 69, Name = "Zipaquirá", DepartamentId = 14 },
                new Munisipality { Id = 70, Name = "Girardot", DepartamentId = 14 },

                // 15. Guainía
                new Munisipality { Id = 71, Name = "Inírida", DepartamentId = 15 },
                new Munisipality { Id = 72, Name = "Barranco Minas", DepartamentId = 15 },
                new Munisipality { Id = 73, Name = "San Felipe", DepartamentId = 15 },
                new Munisipality { Id = 74, Name = "Puerto Colombia", DepartamentId = 15 },
                new Munisipality { Id = 75, Name = "La Guadalupe", DepartamentId = 15 },

                // 16. Guaviare
                new Munisipality { Id = 76, Name = "San José del Guaviare", DepartamentId = 16 },
                new Munisipality { Id = 77, Name = "Calamar", DepartamentId = 16 },
                new Munisipality { Id = 78, Name = "Miraflores", DepartamentId = 16 },
                new Munisipality { Id = 79, Name = "El Retorno", DepartamentId = 16 },
                new Munisipality { Id = 80, Name = "La Libertad", DepartamentId = 16 },

                // 17. Huila (TODOS LOS MUNICIPIOS)
                new Munisipality { Id = 200, Name = "Neiva", DepartamentId = 17 },
                new Munisipality { Id = 201, Name = "Acevedo", DepartamentId = 17 },
                new Munisipality { Id = 202, Name = "Agrado", DepartamentId = 17 },
                new Munisipality { Id = 203, Name = "Aipe", DepartamentId = 17 },
                new Munisipality { Id = 204, Name = "Algeciras", DepartamentId = 17 },
                new Munisipality { Id = 205, Name = "Altamira", DepartamentId = 17 },
                new Munisipality { Id = 206, Name = "Baraya", DepartamentId = 17 },
                new Munisipality { Id = 207, Name = "Campoalegre", DepartamentId = 17 },
                new Munisipality { Id = 208, Name = "Colombia", DepartamentId = 17 },
                new Munisipality { Id = 209, Name = "Elías", DepartamentId = 17 },
                new Munisipality { Id = 210, Name = "Garzón", DepartamentId = 17 },
                new Munisipality { Id = 211, Name = "Gigante", DepartamentId = 17 },
                new Munisipality { Id = 212, Name = "Guadalupe", DepartamentId = 17 },
                new Munisipality { Id = 213, Name = "Hobo", DepartamentId = 17 },
                new Munisipality { Id = 214, Name = "Íquira", DepartamentId = 17 },
                new Munisipality { Id = 215, Name = "Isnos", DepartamentId = 17 },
                new Munisipality { Id = 216, Name = "La Argentina", DepartamentId = 17 },
                new Munisipality { Id = 217, Name = "La Plata", DepartamentId = 17 },
                new Munisipality { Id = 218, Name = "Nátaga", DepartamentId = 17 },
                new Munisipality { Id = 219, Name = "Oporapa", DepartamentId = 17 },
                new Munisipality { Id = 220, Name = "Paicol", DepartamentId = 17 },
                new Munisipality { Id = 221, Name = "Palermo", DepartamentId = 17 },
                new Munisipality { Id = 222, Name = "Palestina", DepartamentId = 17 },
                new Munisipality { Id = 223, Name = "Pital", DepartamentId = 17 },
                new Munisipality { Id = 224, Name = "Pitalito", DepartamentId = 17 },
                new Munisipality { Id = 225, Name = "Rivera", DepartamentId = 17 },
                new Munisipality { Id = 226, Name = "Saladoblanco", DepartamentId = 17 },
                new Munisipality { Id = 227, Name = "San Agustín", DepartamentId = 17 },
                new Munisipality { Id = 228, Name = "Santa María", DepartamentId = 17 },
                new Munisipality { Id = 229, Name = "Suaza", DepartamentId = 17 },
                new Munisipality { Id = 230, Name = "Tarqui", DepartamentId = 17 },
                new Munisipality { Id = 231, Name = "Tello", DepartamentId = 17 },
                new Munisipality { Id = 232, Name = "Teruel", DepartamentId = 17 },
                new Munisipality { Id = 233, Name = "Tesalia", DepartamentId = 17 },
                new Munisipality { Id = 234, Name = "Timaná", DepartamentId = 17 },
                new Munisipality { Id = 235, Name = "Villavieja", DepartamentId = 17 },
                new Munisipality { Id = 236, Name = "Yaguará", DepartamentId = 17 },

                 // 18. La Guajira
                new Munisipality { Id = 81, Name = "Riohacha", DepartamentId = 18 },
                new Munisipality { Id = 82, Name = "Maicao", DepartamentId = 18 },
                new Munisipality { Id = 83, Name = "Uribia", DepartamentId = 18 },
                new Munisipality { Id = 84, Name = "Fonseca", DepartamentId = 18 },
                new Munisipality { Id = 85, Name = "Manaure", DepartamentId = 18 },

                // 19. Magdalena
                new Munisipality { Id = 86, Name = "Santa Marta", DepartamentId = 19 },
                new Munisipality { Id = 87, Name = "Ciénaga", DepartamentId = 19 },
                new Munisipality { Id = 88, Name = "Fundación", DepartamentId = 19 },
                new Munisipality { Id = 89, Name = "Plato", DepartamentId = 19 },
                new Munisipality { Id = 90, Name = "Pivijay", DepartamentId = 19 },

                // 20. Meta
                new Munisipality { Id = 91, Name = "Villavicencio", DepartamentId = 20 },
                new Munisipality { Id = 92, Name = "Acacías", DepartamentId = 20 },
                new Munisipality { Id = 93, Name = "Granada", DepartamentId = 20 },
                new Munisipality { Id = 94, Name = "Puerto López", DepartamentId = 20 },
                new Munisipality { Id = 95, Name = "Cumaral", DepartamentId = 20 },

                // 21. Nariño
                new Munisipality { Id = 96, Name = "Pasto", DepartamentId = 21 },
                new Munisipality { Id = 97, Name = "Ipiales", DepartamentId = 21 },
                new Munisipality { Id = 98, Name = "Tumaco", DepartamentId = 21 },
                new Munisipality { Id = 99, Name = "Túquerres", DepartamentId = 21 },
                new Munisipality { Id = 100, Name = "La Unión", DepartamentId = 21 },

                // 22. Norte de Santander
                new Munisipality { Id = 101, Name = "Cúcuta", DepartamentId = 22 },
                new Munisipality { Id = 102, Name = "Ocaña", DepartamentId = 22 },
                new Munisipality { Id = 103, Name = "Pamplona", DepartamentId = 22 },
                new Munisipality { Id = 104, Name = "Villa del Rosario", DepartamentId = 22 },
                new Munisipality { Id = 105, Name = "Los Patios", DepartamentId = 22 },

                // 23. Putumayo
                new Munisipality { Id = 106, Name = "Mocoa", DepartamentId = 23 },
                new Munisipality { Id = 107, Name = "Puerto Asís", DepartamentId = 23 },
                new Munisipality { Id = 108, Name = "Orito", DepartamentId = 23 },
                new Munisipality { Id = 109, Name = "Villagarzón", DepartamentId = 23 },
                new Munisipality { Id = 110, Name = "Sibundoy", DepartamentId = 23 },

                // 24. Quindío
                new Munisipality { Id = 111, Name = "Armenia", DepartamentId = 24 },
                new Munisipality { Id = 112, Name = "Calarcá", DepartamentId = 24 },
                new Munisipality { Id = 113, Name = "La Tebaida", DepartamentId = 24 },
                new Munisipality { Id = 114, Name = "Montenegro", DepartamentId = 24 },
                new Munisipality { Id = 115, Name = "Quimbaya", DepartamentId = 24 },

                // 25. Risaralda
                new Munisipality { Id = 116, Name = "Pereira", DepartamentId = 25 },
                new Munisipality { Id = 117, Name = "Dosquebradas", DepartamentId = 25 },
                new Munisipality { Id = 118, Name = "Santa Rosa de Cabal", DepartamentId = 25 },
                new Munisipality { Id = 119, Name = "La Virginia", DepartamentId = 25 },
                new Munisipality { Id = 120, Name = "Marsella", DepartamentId = 25 },

                // 26. San Andrés y Providencia
                new Munisipality { Id = 121, Name = "San Andrés", DepartamentId = 26 },
                new Munisipality { Id = 122, Name = "Providencia", DepartamentId = 26 },
                new Munisipality { Id = 123, Name = "Santa Catalina", DepartamentId = 26 },
                new Munisipality { Id = 124, Name = "Cove Sea Side", DepartamentId = 26 },
                new Munisipality { Id = 125, Name = "La Loma", DepartamentId = 26 },

                // 27. Santander
                new Munisipality { Id = 126, Name = "Bucaramanga", DepartamentId = 27 },
                new Munisipality { Id = 127, Name = "Floridablanca", DepartamentId = 27 },
                new Munisipality { Id = 128, Name = "Girón", DepartamentId = 27 },
                new Munisipality { Id = 129, Name = "Piedecuesta", DepartamentId = 27 },
                new Munisipality { Id = 130, Name = "Barrancabermeja", DepartamentId = 27 },

                // 28. Sucre
                new Munisipality { Id = 131, Name = "Sincelejo", DepartamentId = 28 },
                new Munisipality { Id = 132, Name = "Corozal", DepartamentId = 28 },
                new Munisipality { Id = 133, Name = "Sampués", DepartamentId = 28 },
                new Munisipality { Id = 134, Name = "San Marcos", DepartamentId = 28 },
                new Munisipality { Id = 135, Name = "Tolú", DepartamentId = 28 },

                // 29. Tolima
                new Munisipality { Id = 136, Name = "Ibagué", DepartamentId = 29 },
                new Munisipality { Id = 137, Name = "Espinal", DepartamentId = 29 },
                new Munisipality { Id = 138, Name = "Melgar", DepartamentId = 29 },
                new Munisipality { Id = 139, Name = "Honda", DepartamentId = 29 },
                new Munisipality { Id = 140, Name = "Líbano", DepartamentId = 29 },

                // 30. Valle del Cauca
                new Munisipality { Id = 141, Name = "Cali", DepartamentId = 30 },
                new Munisipality { Id = 142, Name = "Palmira", DepartamentId = 30 },
                new Munisipality { Id = 143, Name = "Buenaventura", DepartamentId = 30 },
                new Munisipality { Id = 144, Name = "Tuluá", DepartamentId = 30 },
                new Munisipality { Id = 145, Name = "Buga", DepartamentId = 30 },

                // 31. Vaupés
                new Munisipality { Id = 146, Name = "Mitú", DepartamentId = 31 },
                new Munisipality { Id = 147, Name = "Carurú", DepartamentId = 31 },
                new Munisipality { Id = 148, Name = "Pacoa", DepartamentId = 31 },
                new Munisipality { Id = 149, Name = "Taraira", DepartamentId = 31 },
                new Munisipality { Id = 150, Name = "Yavaraté", DepartamentId = 31 },

                // 32. Vichada
                new Munisipality { Id = 151, Name = "Puerto Carreño", DepartamentId = 32 },
                new Munisipality { Id = 152, Name = "La Primavera", DepartamentId = 32 },
                new Munisipality { Id = 153, Name = "Santa Rosalía", DepartamentId = 32 },
                new Munisipality { Id = 154, Name = "Cumaribo", DepartamentId = 32 },
                new Munisipality { Id = 155, Name = "Guarrojo", DepartamentId = 32 }
            );
        }
    }
}
