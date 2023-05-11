using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CriasApp.Models
{

    public class Usuarios
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int IdUser { get; set; }

        public string? Usuario { get; set; }

        public string? Contraseña { get; set; }

        public string? Puesto { get; set; }
    }

}