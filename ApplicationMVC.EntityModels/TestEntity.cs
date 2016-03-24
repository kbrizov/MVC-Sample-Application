using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApplicationMVC.EntityModels
{
    [Bind(Include = "Id, Number, Text")]
    public class TestEntity
    {
        public int Id { get; set; }

        [Range(1, 100)]
        public int Number { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
