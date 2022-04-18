using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HDI.Controller
{
    public class Flujo_Out
    {
        [Key]
        public string respuesta { get; set; }

    }
     public class Flujo_Out_respuesta
    {
        [Key]
        public string nroSimulacion { get; set; }
        public string status { get; set; }
        public string statusCode { get; set; }
        public string message { get; set; }

    }

    public class Flujo_in
    {
        [Key]
      //  public string ID { get; set; }
        public int Simulacion { get; set; }
        public int PasoWeb { get; set; }
        public string MarcaModeloAnioTipoVehiculo { get; set; }
        public int Rut { get; set; }
        public string DV { get; set; }
        public int DuenoVehiculo { get; set; }
        public int RutDueno { get; set; }
        public string DVDueno { get; set; }
        public int Deducible { get; set; }
        public int ResponsabilidadCivil { get; set; }
        public int AutoReemplazo { get; set; }
        public int VehiculoNuevo { get; set; }
        public string Patente { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Campana { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int Prioridad { get; set; } 
        public string fechaCotizacion { get; set; }
     //   public string detalle { get; set; }


    }



    public class Flujo_in_paso_1
    {
        [Key]

        public string Simulacion { get; set; }
        public string PasoWeb { get; set; }
        public string MarcaModeloAnioTipoVehiculo { get; set; }
        public string Rut { get; set; }
        public string DV { get; set; }
        public string DuenoVehiculo { get; set; }
        public string RutDueno { get; set; }
        public string DVDueno { get; set; }      
        public string Campana { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
     


    }
    public class Flujo_in_paso_2
    {
        [Key]

        public string Simulacion { get; set; }
        public string PasoWeb { get; set; }
        public string Deducuble { get; set; }
        public string ResponsabilidadCivil { get; set; }
        public string AutoReemplazo { get; set; }
        


    }
    public class Flujo_in_paso_3
    {
        [Key]

        public string Simulacion { get; set; }
        public string PasoWeb { get; set; }
        public string VehiculoNuevo { get; set; }
        public string Patente { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string fechaCotizacion { get; set; }

    
    }
    public class Flujo_in_paso_4
    {
        [Key]

        public string Simulacion { get; set; }
        public string PasoWeb { get; set; }     
        public string Campana { get; set; }
     

    }
}
