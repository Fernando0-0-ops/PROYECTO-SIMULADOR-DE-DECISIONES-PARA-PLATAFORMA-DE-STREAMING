//segundos errores
Console.WriteLine("Sistema de cajero automatico simulado");

do
{
    //mostar menu
    Console.WriteLine("1. Evaluar contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadisticas de la sesion");
    Console.WriteLine("4. Reiniciar estadisticas");
    Console.WriteLine("5. Salir");

    Console.WriteLine("Ingrese una opcion:");
    int opcion = int.Parse(Console.ReadLine()); // ❌ Puede fallar si el usuario ingresa texto

    //  Estas variables se reinician en cada vuelta del ciclo (pierdes las estadísticas)
    int evaluados = 0;
    int rechazados = 0;
    int publicados = 0;

    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ingrese que tipo de contenido es: ");
            string contenido = Console.ReadLine();

            Console.WriteLine("Ingrese la duración en MINUTOS: ");
            int duracion = int.Parse(Console.ReadLine()); // ❌ Sin validación

            Console.WriteLine("Ingrese a que clasificación pertenece: ");
            string clasificacion = Console.ReadLine();

            Console.WriteLine("Ingrese el horario deseado (entre 0 y 23): ");
            int horario = int.Parse(Console.ReadLine()); // ❌ No validas rango (0–23)

            Console.WriteLine("¿Nivel de producción?");
            string produccion = Console.ReadLine();

            evaluados++;

            //Regla 1
            void Regla1()
            {
                if (clasificacion == "Todo publico")
                {
                    Regla2();
                }
                //  Tiene espacios incorrectos → nunca coincidirá correctamente
                else if (clasificacion == " +13 " && horario >= 6 && horario <= 22)
                {
                    Regla2();
                }
                else if (clasificacion == "+18" && (horario >= 22 || horario <= 5))
                {
                    Regla2();
                }
                else
                {
                    Console.WriteLine("Rechazado");
                    Console.WriteLine("Motivo: horario no permitido para la clasificación");
                    rechazados++;
                }
            }

            //Regla 2
            void Regla2()
            {
                //  Comparaciones sensibles a mayúsculas (pelicula vs Pelicula)
                if (contenido == "pelicula" && duracion > 60 && duracion <= 180)
                {
                    Regla3();
                }
                else if (contenido == "serie" && duracion > 20 && duracion <= 90)
                {
                    Regla3();
                }
                else if (contenido == "documental" && duracion > 30 && duracion <= 120)
                {
                    Regla3();
                }
                else if (contenido == "evento" && duracion > 30 && duracion <= 240)
                {
                    Regla3();
                }
                else
                {
                    Console.WriteLine("Rechazado");
                    Console.WriteLine("Motivo: duración fuera del rango permitido");
                    rechazados++;
                }

                //Regla 3
                void Regla3()
                {
                    //  Inconsistencia de texto "+18" vs lo que el usuario puede escribir
                    if (produccion == "bajo" && clasificacion == "+18")
                    {
                        Console.WriteLine("Rechazado");
                        Console.WriteLine("Motivo: la producción baja no es permitida para clasificación +18");
                        rechazados++;
                    }
                    else
                    {
                        impacto();
                        decision_final(); //  Esta función está fuera de Regla2 (confuso)
                    }
                }

                //Impacto 
                void impacto()
                {
                    //  Uso de OR (||) puede dar resultados incorrectos
                    if (produccion == "alto" || duracion > 120 || (horario >= 20 && horario <= 23))
                    {
                        Console.WriteLine("Impacto: ALTO ");
                    }
                    else if (produccion == "medio" || (duracion > 60 && duracion <= 120))
                    {
                        Console.WriteLine("Impacto: MEDIO ");
                    }
                    else if (produccion == "bajo" && duracion < 60)
                    {
                        Console.WriteLine("Impacto: BAJO ");
                    }
                }
            }

            //Decisión final
            void decision_final()
            {
                //  Problema de mayúsculas ("Bajo" vs "bajo")
                if (produccion == "Bajo" || produccion == "Medio")
                {
                    Console.WriteLine("Decisión final: Publicar");
                    publicados++;
                }
                else if (produccion == "Alto")
                {
                    Console.WriteLine("Decision final: Enviar a revisión");
                }
                //  Falta un else para cubrir otros casos (rechazo)
            }

            Regla1(); // ✅ Bien, aquí sí llamas la función

            break;

        case 2:
            //  No implementado
            break;

        case 3:
            //  No muestra estadísticas aunque tienes variables
            break;

        case 4:
            //  No reinicia estadísticas realmente
            break;

        case 5:
            //  No muestra mensaje de salida
            break;
    }

    //  ERROR GRAVE: opcion está fuera de alcance aquí (scope)
    // porque fue declarada dentro del do {}
} while (opcion != 5);