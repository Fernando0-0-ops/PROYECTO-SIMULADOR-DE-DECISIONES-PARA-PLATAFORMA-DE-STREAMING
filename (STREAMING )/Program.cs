Console.WriteLine("Sistema de evaluacion de contenido de streaming");

int opcion;

int evaluados = 0;
int rechazados = 0;
int publicados = 0;

do
{
    Console.WriteLine("\n1. Evaluar contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadisticas de la sesion");
    Console.WriteLine("4. Reiniciar estadisticas");
    Console.WriteLine("5. Salir");

    Console.Write("Ingrese una opcion: ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            Console.Write("Tipo de contenido: ");
            string contenido = Console.ReadLine().ToLower();

            Console.Write("Duración (minutos): ");
            int duracion = int.Parse(Console.ReadLine());

            Console.Write("Clasificación: ");
            string clasificacion = Console.ReadLine().ToLower();

            Console.Write("Horario (0-23): ");
            int horario = int.Parse(Console.ReadLine());

            while (horario < 0 || horario > 23)
            {
                Console.Write("Horario inválido, ingrese nuevamente: ");
                horario = int.Parse(Console.ReadLine());
            }

            Console.Write("Nivel de producción: ");
            string produccion = Console.ReadLine().ToLower();

            evaluados++;

            // REGLA 1
            if (clasificacion == "+13" && (horario < 6 || horario > 22))
            {
                Console.WriteLine("Rechazado");
                rechazados++;
                break;
            }

            if (clasificacion == "+18" && !(horario >= 22 || horario <= 5))
            {
                Console.WriteLine("Rechazado");
                rechazados++;
                break;
            }

            // "todo publico" pasa sin restricciones

            // REGLA 2
            if (contenido == "pelicula" && !(duracion >= 60 && duracion <= 180))
            {
                Console.WriteLine("Rechazado");
                rechazados++;
                break;
            }

            if (contenido == "serie" && !(duracion >= 20 && duracion <= 90))
            {
                Console.WriteLine("Rechazado");
                rechazados++;
                break;
            }

            if (contenido == "documental" && !(duracion >= 30 && duracion <= 120))
            {
                Console.WriteLine("Rechazado");
                rechazados++;
                break;
            }

            if (contenido == "evento" && !(duracion >= 30 && duracion <= 240))
            {
                Console.WriteLine("Rechazado");
                rechazados++;
                break;
            }

            // REGLA 3
            if (produccion == "bajo" && clasificacion == "+18")
            {
                Console.WriteLine("Rechazado");
                rechazados++;
                break;
            }

            // IMPACTO
            string impacto;

            if (produccion == "alto" || duracion > 120 || (horario >= 20 && horario <= 23))
                impacto = "ALTO";
            else if (produccion == "medio" || (duracion >= 60 && duracion <= 120))
                impacto = "MEDIO";
            else
                impacto = "BAJO";

            Console.WriteLine("Impacto: " + impacto);

            // DECISION FINAL
            if (impacto == "BAJO" || impacto == "MEDIO")
            {
                Console.WriteLine("Publicar");
                publicados++;
            }
            else
            {
                Console.WriteLine("Enviar a revisión");
            }

            break;

        case 2:
            Console.WriteLine("\n=== REGLAS ===");
            Console.WriteLine("Todo público: cualquier horario");
            Console.WriteLine("+13: de 6 a 22");
            Console.WriteLine("+18: de 22 a 5");

            Console.WriteLine("Película: 60-180 min");
            Console.WriteLine("Serie: 20-90 min");
            Console.WriteLine("Documental: 30-120 min");
            Console.WriteLine("Evento: 30-240 min");

            Console.WriteLine("Producción baja no permitida en +18");
            break;

        case 3:
            Console.WriteLine("\n=== ESTADISTICAS ===");
            Console.WriteLine("Evaluados: " + evaluados);
            Console.WriteLine("Publicados: " + publicados);
            Console.WriteLine("Rechazados: " + rechazados);

            if (evaluados > 0)
            {
                double porcentaje = (double)publicados / evaluados * 100;
                Console.WriteLine("Porcentaje de aprobación: " + porcentaje.ToString("0.00") + "%");
            }
            else
            {
                Console.WriteLine("No hay datos aún");
            }
            break;

        case 4:
            evaluados = 0;
            rechazados = 0;
            publicados = 0;

            Console.WriteLine("Estadísticas reiniciadas");
            break;

        case 5:
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción inválida");
            break;
    }

} while (opcion != 5);