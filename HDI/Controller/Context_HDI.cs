using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HDI.Controller
{
    public class Context_HDI : DbContext
    {

        public Context_HDI(DbContextOptions<Context_HDI> options) : base(options)
        {


        }


        public DbSet<HDI.Controller.Flujo_Out> flujo_Outs { get; set; }
        public DbSet<HDI.Controller.Flujo_Out_respuesta> flujo_Out_Respuestas { get; set; }
        public DbSet<HDI.Controller.Flujo_in> flujo_Ins { get; set; }
        public DbSet<HDI.Controller.Flujo_in_paso_1> flujo_In_Paso_1s { get; set; }
        public DbSet<HDI.Controller.Flujo_in_paso_2> flujo_In_Paso_2s { get; set; }
        public DbSet<HDI.Controller.Flujo_in_paso_3> flujo_In_Paso_3s { get; set; }
        public DbSet<HDI.Controller.Flujo_in_paso_4> flujo_In_Paso_4s { get; set; }

    }
}
