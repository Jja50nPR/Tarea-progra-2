using System;

namespace Tarea
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MenuPrincipal();

        }
    }

    class Menu
    {
        private static int Contador;
        private static bool seguir = true;
        private static bool seguirB = true;
        private static bool seguirC = true;

        public static void EvaluarOpcion(string pOpcion)
        {
            Menu menu = new Menu();

            switch (pOpcion)
            {
                case "1":
                    Datos.InicializarVectores();
                    break;
                case "2":
                    Datos.IngresarDatos();
                    break;
                case "3":
                    Datos.Buscar();
                    break;
                case "4":
                    Datos.Modificar();
                    break;
                case "5":
                    Datos.Reportar();
                    break;
                case "6":
                    SalirMenu();
                    break;
                default:
                    Console.WriteLine("Opción invalida");
                    break;
            }
        }

        public static void SegundaEvaluarOpcion(string pOpcion)
        {
            Datos datos = new Datos();
            switch (pOpcion)
            {
                case "1":
                    datos.setTipoVehiculo("Motocicleta");
                    Contador = 1;
                    seguirB = false;
                    break;
                case "2":
                    datos.setTipoVehiculo("Vehiculo liviano");
                    Contador = 2;
                    seguirB = false;
                    break;
                case "3":
                    datos.setTipoVehiculo("Camion o vehiculo pesado");
                    Contador = 3;
                    seguirB = false;
                    break;
                case "4":
                    datos.setTipoVehiculo("Autobus");
                    Contador = 4;
                    seguirB = false;
                    break;
                default:
                    Console.WriteLine("Ha ingresado un valor invalido");
                    break;
            }
        }

        public static void TerceraEvaluarOpcion(string pOpcion)
        {
            Datos datos = new Datos();
            switch (pOpcion)
            {
                case "1":
                    datos.setNumeroCaseta("Caseta 1");
                    seguirC = false;
                    break;
                case "2":
                    datos.setNumeroCaseta("Caseta 2");
                    seguirC = false;
                    break;
                case "3":
                    datos.setNumeroCaseta("Caseta 3");
                    seguirC = false;
                    break;
                default:
                    Console.WriteLine("Ha ingresado un valor invalido");
                    break;
            }

        }


        public static void SalirMenu()
        {
            Console.WriteLine("****************************");
            string confirmacion = leerAlfaNumerico("¿Realmente desea salir? S/N");
            if (confirmacion.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                seguir = false;
                Console.WriteLine("Has salido del menu");
                Console.WriteLine("Adios!!!!");

            }
            else
            {
                Console.WriteLine("No has salido del menu");
                Console.WriteLine("Continue navegando por el menu");
            }

        }

        public void ImprimirMenu()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("1-Inicializar vectores");
            Console.WriteLine("2-Ingresar paso vehicular");
            Console.WriteLine("3-Consulta de vehiculos por número de placa");
            Console.WriteLine("4-Modificar datos vehiculos por número de placa");
            Console.WriteLine("5-Reporte todos los datos de los vectores");
            Console.WriteLine("6-Salir");
            Console.WriteLine("****************************");
        }

        public void VehiculoMenu()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("1-Motocicleta");
            Console.WriteLine("2-Vehiculo liviano");
            Console.WriteLine("3-Camion o vehiculo pesado");
            Console.WriteLine("4-Autobus");
            Console.WriteLine("****************************");
        }

        public void CasetaMenu()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("1-Caseta 1");
            Console.WriteLine("2-Caseta 2");
            Console.WriteLine("3-Caseta 3");
            Console.WriteLine("****************************");

        }


        public void MenuPrincipal()
        {
            while (seguir)
            {
                ImprimirMenu();
                string opcion = leerAlfaNumerico("Ingrese la opción deseada");
                EvaluarOpcion(opcion);
            }

        }

        public void MenuVehiculo()
        {
            seguirB = true;
            while (seguirB ==true)
            {
                VehiculoMenu();
                Console.WriteLine("Ingrese el tipo de su vehiculo : ");
                string opcion = leerAlfaNumerico("Ingrese la opción deseada");
                SegundaEvaluarOpcion(opcion);

            }
        }

        public void MenuCaseta()
        {
            seguirC = true;
            while (seguirC)
            {
                CasetaMenu();
                Console.WriteLine("Ingrese la caseta que desea para su vehiculo");
                string opcion = leerAlfaNumerico("Ingrese la opción deseada");
                TerceraEvaluarOpcion(opcion);

            }

        }


        public static string leerAlfaNumerico(string pMensaje)
        {
            Console.WriteLine(pMensaje);
            string dato = Console.ReadLine();
            return dato;

        }

        public static int leerEntero(String pMensaje)
        {
            int bandera = 0;
            int dato = 0;
            Console.WriteLine(pMensaje);
            while (bandera == 0)
            {
                try
                {
                    dato = int.Parse(Console.ReadLine());
                    bandera++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Has introducido un valor equivocado");
                    Console.WriteLine("Vuelva ha introducir el valor");
                }
            }

            return dato;
        }

        public int getContador()
        {
            return Contador;
        }

        public void setTipoVehiculo(int pContador)
        {
            Contador = pContador;
        }
    }

    class Datos
    {
        private static int monto;
        private static string factura;
        private static string numeroPlaca;
        private static string fecha;
        private static string hora;
        private static string tipoVehiculo;
        private static string numeroCaseta;
        private static string montoPagar;
        private static int dineroCliente;
        private static int VueltoDineroCliente;
        private static int pos = 0;
        private static string[] placas = new string[15];
        private static string[] general = new string[15];
        private static int[] dinero = new int[15];
        private static int[] dineroB = new int[15];


        public static void IngresarDatos()
        {
            Menu menu = new Menu();
            string opcion;
            int bandera = 0;
            
            do
            {
                try
                {
                    Console.WriteLine("Hay un espacio limitado de 15 espacios para vehiculos");
                    Pedirdatos();
                    menu.MenuVehiculo();
                    menu.MenuCaseta();
                    Cobro();
                    placas[pos] = numeroPlaca;
                    general[pos] = "El numero de factura es :  " + factura + "\n" +  "La fecha en la que el vehiculo fue ingresado es :  " + fecha + "\n" +
                        "La hora a la que el vehiculo fue ingresado es : " + hora + "\n" + "El tipo de vehiculo ingresado es : " + tipoVehiculo + "\n" +
                        "El numero de caseta del vehiculo es : " + numeroCaseta + "\n" + "El monto a pagar del vehiculo es : " + montoPagar;
                    Vuelto();
                    dinero[pos] = dineroCliente;
                    dineroB[pos] = VueltoDineroCliente;
                    pos++;
                    opcion = Menu.leerAlfaNumerico("¿Desea agregar otro vehiculo? S/N");
                    if (opcion.Equals("s", StringComparison.OrdinalIgnoreCase) == false && opcion.Equals("n", StringComparison.OrdinalIgnoreCase) == false)
                    {
                        Console.WriteLine("No ha ingresado S o N para responder a la pregunta");
                        
                    }
                    else
                    {
                        if (opcion.Equals("s", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            bandera = 0;
                        }
                        else
                        {
                            if (opcion.Equals("n", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                bandera++;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Ya no hay mas espacio para agregar mas vehículos");
                    bandera++;
                }

            } while (bandera == 0);

           
        }

        public static void Pedirdatos()
        {
            factura = Menu.leerAlfaNumerico("Ingrese el numero de factura del vehiculo :");
            numeroPlaca = Menu.leerAlfaNumerico("Ingrese el numero de placa del vehiculo :");
            fecha = Menu.leerAlfaNumerico("Ingrese la fecha en la que sera ingresado el vehiculo :");
            hora = Menu.leerAlfaNumerico("Ingrese la hora en la que sera ingresado el vehiculo :");
        }

        public static void Cobro()
        {
            Menu menu = new Menu();

            if (menu.getContador() == 2)
            {
                montoPagar = "700";
                monto = 700;

            }
            else
            {
                if (menu.getContador() == 3)
                {
                    montoPagar = "2700";
                    monto = 2700;
                }
                else
                {
                    if (menu.getContador() == 1)
                    {
                        montoPagar = "500";
                        monto = 500;

                    }
                    else
                    {
                        if (menu.getContador() == 4)
                        {
                            montoPagar = "3700";
                            monto = 3700;

                        }
                    }
                }
            }

        }

        public static void Vuelto()
        {

            int bandera = 0;
            while (bandera == 0)
            {
                dineroCliente = Menu.leerEntero("Ingrese el monto con el que va a pagar : ");
                VueltoDineroCliente = dineroCliente - monto;
                if (VueltoDineroCliente < 0)
                {
                    Console.WriteLine("El monto no ha sido suficiente para efectuar el pago");
                    Console.WriteLine("Vuelva a introducir otro monto con el que desea pagar");

                }
                else
                {
                    if (VueltoDineroCliente > 0)
                    {
                        Console.WriteLine("Su vuelto es de " + VueltoDineroCliente);
                        Console.WriteLine("Recuerde recoger su dinero");
                        Console.WriteLine("Gracias por efectuar su pago");
                        bandera++;
                    }
                    else
                    {
                        if (VueltoDineroCliente == 0)
                        {
                            Console.WriteLine("Gracias por efectuar su pago");
                            Console.WriteLine("Adios");
                            bandera++;
                        }
                    }
                }
            }

        }

        public static void InicializarVectores()
        {
            for (int i = 0; i < 15; i++)
            {
                placas[i] = " ";
                general[i] = " ";
                dinero[i] = 0;
                dineroB[i] = 0;
            }
            Console.WriteLine("Se han inicializado los vectores");
            pos = 0;
        }

        public static void Reportar()
        {
            for (int i = 0; i < general.Length; i++)
            {
                Console.WriteLine(general[i]);
                if (dinero[i] != 0)
                {
                    Console.WriteLine("La cantidad de dinero con la que pago el cliente fue : " + dinero[i]);
                    Console.WriteLine("El vuelto del cliente es : " + dineroB[i]);
                }
                if (general[i] != " " && dinero[i] !=0)
                {
                    Console.WriteLine("******************************************************************");
                }
            }

            Console.WriteLine("Cantidad de vehiculos : " + pos);
        }

        public static void Buscar()
        {
            string search = Menu.leerAlfaNumerico("Ingrese la placa del vehiculo que desea buscar  ");

            try
            {
                int index = Array.IndexOf(placas, search);
                Console.WriteLine("Datos del vehiculo");
                Console.WriteLine(general[index]);
                Console.WriteLine("Dinero del cliente : " + dinero[index]);
                Console.WriteLine("Vuelto del dinero del cliente : " + dineroB[index]);

            }
            catch (IndexOutOfRangeException)
            {

                Console.WriteLine("El vehiculo no ha sido encoontrado ");
                Console.WriteLine("Sera redirigido al menu , si desea volver a buscar un vehiculo" + "\n" + "oprima la opcion 3 y escriba una placa correcta");
            }

          
        }

        public static void Modificar()
        {

            Menu menu = new Menu();
            string search = Menu.leerAlfaNumerico("Ingrese la placa del vehiculo que desea buscar y posteriormente modificar  :");


            try
            {
                int index = Array.IndexOf(placas, search);

                Console.WriteLine("Datos del vehiculo");
                Console.WriteLine(general[index]);
                Console.WriteLine("Dinero del cliente : " + dinero[index]);
                Console.WriteLine("Vuelto del dinero del cliente : " + dineroB[index]);
                Console.WriteLine("**********************************");
                Console.WriteLine("Seguiremos a modificar los datos : ");
                Pedirdatos();
                menu.MenuVehiculo();
                menu.MenuCaseta();
                Cobro();
                placas[index] = numeroPlaca;
                general[index] = "El numero de factura es : " + factura + "\n" + "La fecha en la que el vehiculo fue ingresado es : " + fecha + "\n" +
                    "La hora a la que el vehiculo fue ingresado es : " + hora + "\n" + "El tipo de vehiculo ingresado es : " + tipoVehiculo + "\n" +
                    "El numero de caseta del vehiculo es : " + numeroCaseta + "\n" + "El monto a pagar del vehiculo es : " + montoPagar;
                Vuelto();
                dinero[index] = dineroCliente;
                dineroB[index] = VueltoDineroCliente;
                Console.WriteLine("********************************************");
                Console.WriteLine("Los nuevos datos son : ");
                Console.WriteLine(general[index]);
                Console.WriteLine("La cantidad de dinero con la que pago el cliente fue : " + dinero[index]);
                Console.WriteLine("El vuelto del cliente es : " + dineroB[index]);
                Console.WriteLine("******************************************************************");


            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("La placa del vehiculo a modificar no ha sido encontrada");
                Console.WriteLine("Sera redirigido al menu");
                Console.WriteLine("Si desea colver a intentar modificar un vehiculo" + "\n" + "oprima la opcion 4 e introduzca una placa correcta");
                
            }


       

        }



        public string getTipoVehiculo()
        {
            return tipoVehiculo;
        }

        public void setTipoVehiculo(string ptipoVehiculo)
        {
            tipoVehiculo = ptipoVehiculo;
        }

        public string getNumeroCaseta()
        {
            return numeroCaseta;
        }

        public void setNumeroCaseta(string pnumeroCaseta)
        {
            numeroCaseta = pnumeroCaseta;
        }

    }

}
