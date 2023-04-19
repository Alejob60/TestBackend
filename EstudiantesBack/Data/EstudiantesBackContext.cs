using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EstudiantesBack.Models;

namespace EstudiantesBack.Data
{
    public class EstudiantesBackContext : DbContext
    {
        public EstudiantesBackContext (DbContextOptions<EstudiantesBackContext> options)
            : base(options)
        {
        }

        public DbSet<EstudiantesBack.Models.Estudiante> Estudiante { get; set; } = default!;
    }
}
