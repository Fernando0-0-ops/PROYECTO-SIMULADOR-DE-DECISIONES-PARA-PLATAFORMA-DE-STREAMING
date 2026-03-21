

Console.WriteLine("Sistema de evaluacion de contenido de streaming");

int opcion;

int evaluados = 0;
int rechazados = 0;
int publicados = 0;

do
{
    // mostrar menu
    Console.WriteLine("1. Evaluar contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadisticas de la sesion");
    Console.WriteLine("4. Reiniciar estadisticas");
    Console.WriteLine("5. Salir");

    Console.WriteLine("Ingrese una opcion:");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ingrese que tipo de contenido es: ");
            string contenido = Console.ReadLine().ToLower();

            Console.WriteLine("Ingrese la duración en MINUTOS: ");
            int duracion = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese a que clasificación pertenece: ");
            string clasificacion = Console.ReadLine();

            Console.WriteLine("Ingrese el horario deseado (entre 0 y 23): ");
            int horario = int.Parse(Console.ReadLine());

            while (horario < 0 || horario > 23)
            {
                Console.WriteLine("Horario inválido, ingrese de nuevo:");
                horario = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("¿Nivel de producción?");
            string produccion = Console.ReadLine().ToLower();

            evaluados++;

            //////////////////Regla 1///////////////////////////////////////////////

            if (clasificacion == "Todo publico")
            {

            }
            else if (clasificacion == "+13" && (horario < 6 || horario > 22))
            {
                Console.WriteLine("Decisión: Rechazado");
                Console.WriteLine("Motivo: +13 solo se permite entre 6 y 22 horas");
                rechazados++;
                break;
            }
            else if (clasificacion == "+18" && !(horario >= 22 || horario <= 5))
            {
                Console.WriteLine("Decisión: Rechazado");
                Console.WriteLine("Motivo: +18 solo se permite entre 22 y 5 horas");
                rechazados++;
                break;
            }

            //////////////////Regla 2///////////////////////////////////////////////
            if (contenido == "pelicula" && !(duracion >= 60 && duracion <= 180))
            {
                Console.WriteLine("Decisión: Rechazado");
                Console.WriteLine("Motivo: duración invalida para pelicula ");
                rechazados++;
                break;
            }
            else if (contenido == "serie" && !(duracion >= 20 && duracion <= 90))
            {
                Console.WriteLine("Decisión: Rechazado");
                Console.WriteLine("Motivo: duración invalida para serie ");
                rechazados++;
                break;
            }
            else if (contenido == "documental" && !(duracion >= 30 && duracion <= 120))
            {
                Console.WriteLine("Decisión: Rechazado");
                Console.WriteLine("Motivo: duración invalida para documental");
                rechazados++;
                break;
            }
            else if (contenido == "evento" && !(duracion >= 30 && duracion <= 240))
            {
                Console.WriteLine("Decisión: Rechazado");
                Console.WriteLine("Motivo: duración invalida para evento en vivo ");
                rechazados++;
                break;
            }

            //////////////////Regla 3///////////////////////////////////////////////

            if (produccion == "bajo" && clasificacion == "+18")
            {
                Console.WriteLine("Decisión: Rechazado");
                Console.WriteLine("Motivo: la producción baja no es permitida para clasificación +18");
                rechazados++;
                break;
            }

            //Impacto ///////////////////////////////////////////////////////
            string impacto = "";

            if (produccion == "alto" || duracion > 120 || (horario >= 20 && horario <= 23))
            {
                impacto = "ALTO";
            }
            else if (produccion == "medio" || (duracion >= 60 && duracion <= 120))
            {
                impacto = "MEDIO";
            }
            else
            {
                impacto = "BAJO";
            }

            Console.WriteLine("Impacto detectado: " + impacto);

            //Decisión final//////////////////////////////////////////////

            if (impacto == "BAJO" || impacto == "MEDIO")
            {
                Console.WriteLine("Decisión final: Publicar");
                publicados++;
            }
            else if (impacto == "ALTO")
            {
                Console.WriteLine("Decision final: Enviar a revisión");
            }

            break;

        case 2:
            Console.WriteLine("= Reglas del sistema =");

            Console.WriteLine("\nClasificación y horario:");
            Console.WriteLine("Todo público: cualquier hora");
            Console.WriteLine("+13: entre 6 y 22 horas");
            Console.WriteLine("+18: entre 22 y 5 horas");

            Console.WriteLine("\nDuración por tipo:");
            Console.WriteLine("Película: 60–180 minutos");
            Console.WriteLine("Serie: 20–90 minutos");
            Console.WriteLine("Documental: 30–120 minutos");
            Console.WriteLine("Evento en vivo: 30–240 minutos");

            Console.WriteLine("\nProducción:");
            Console.WriteLine("Producción baja: solo Todo público o +13");
            Console.WriteLine("Producción media o alta: cualquier clasificación");

            break;

        case 3:
            break;

        case 4:
            break;

        case 5:
            break;
    }

} while (opcion != 5);