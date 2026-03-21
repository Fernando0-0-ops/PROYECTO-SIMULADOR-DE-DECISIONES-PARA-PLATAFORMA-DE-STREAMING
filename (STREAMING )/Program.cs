//  Falta declarar una clase y el método Main para que el programa funcione correctamente

Console.WriteLine("Sistema de cajero automatico simulado");

//  El sistema no está en un ciclo, solo se ejecuta una vez

//mostar menu
Console.WriteLine("1. Evaluar contenido");
Console.WriteLine("2. Mostrar reglas del sistema");
Console.WriteLine("3. Mostrar estadisticas de la sesion");
Console.WriteLine("4. Reiniciar estadisticas");
Console.WriteLine("5. Salir");

Console.WriteLine("Ingrese una opcion:");
int opcion = int.Parse(Console.ReadLine()); //  Puede fallar si el usuario ingresa texto

int evaluados = 0;
int rechazados = 0;
int publicados = 0;

switch (opcion)
{
    case 1:
        Console.WriteLine("Ingrese que tipo de contenido es: ");
        string contenido = Console.ReadLine();

        Console.WriteLine("Ingrese la duración en MINUTOS: ");
        int duracion = int.Parse(Console.ReadLine()); //  Sin validación

        Console.WriteLine("Ingrese a que clasificación pertenece: ");
        string clasificacion = Console.ReadLine();

        Console.WriteLine("Ingrese el horario deseado (entre 0 y 23): ");
        double horario = double.Parse(Console.ReadLine()); //  Debería ser int

        Console.WriteLine("¿Nivel de producción?");
        string produccion = Console.ReadLine();


        //Regla 1
        void Regla1()
        {
            //  Comparaciones con espacios incorrectos
            if (clasificacion == "Todo publico")
            {
                Regla2();
            }
            else if (clasificacion == " +13 ") //  Espacios incorrectos
            {
                Regla2();
            }
            else if (clasificacion == " +18 ") //  Espacios incorrectos
            {
                Regla2();
            }
            else
            {
                Console.WriteLine("Rechazado");
                rechazados++;
            }
        }


        //Regla 2
        void Regla2()
        {
            //  Condiciones repetidas y confusas (se solapan entre sí)
            if (duracion > 60 && duracion <= 180)
            {
                Regla3();
            }
            else if (duracion > 20 && duracion <= 90)
            {
                Regla3();
            }
            else if (duracion > 30 && duracion <= 120)
            {
                Regla3();
            }
            else if (duracion > 30 && duracion <= 240)
            {
                Regla3();
            }
            else
            {
                Console.WriteLine("Rechazado");
                rechazados++;
            }


            //  Función anidada (hace el código difícil de entender)
            void Regla3()
            {
                if (produccion == "bajo" && clasificacion == "+18") //  Inconsistencia con espacios en "+18"
                {
                    Console.WriteLine("Decisión: RECHAZAR");
                    Console.WriteLine("Motivo: la producción baja no es permitida para clasificación +18");
                }
                else
                {
                    //  Regla33 no hace nada
                    Regla33();
                }
            }

            void Regla33()
            {
                //  Función vacía (no tiene utilidad)
            }

            void impacto()
            {
                // No se llama nunca esta función
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

            void decision_final()
            {
                //  Problema de mayúsculas/minúsculas ("Bajo" vs "bajo")
                if (produccion == "Bajo" || produccion == "Medio")
                {
                    Console.WriteLine("Publicar");
                }
                if (produccion == "Alto")
                {
                    Console.WriteLine("Enviar a revisión");
                }
                else
                {
                    //  Este else solo pertenece al segundo if, no al primero
                    Console.WriteLine("Rechazar");
                }
            }
        }

        //  Nunca se llama a Regla1(), por lo tanto nada de la lógica se ejecuta

        break;

    case 2:
        //  No hay implementación
        break;

    case 3:
        //  No hay implementación
        break;

    case 4:
        //  No hay implementación
        break;

    case 5:
        //  No hay mensaje de salida ni cierre
        break;
}//
