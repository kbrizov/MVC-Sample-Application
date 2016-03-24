using ApplicationMVC.EntityModels;
using System.ComponentModel.DataAnnotations;

namespace ApplicationMVC.ViewModels
{
    public class TestModel
    {
        public int Id { get; set; }

        [Range(1, 100)]
        public int Number { get; set; }

        [Required]
        public string Text { get; set; }

        public static TestModel CreateFromTestEntity(TestEntity entity)
        {
            TestModel model = new TestModel()
            {
                Id = entity.Id,
                Number = entity.Number,
                Text = entity.Text
            };

            return model;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Number: {1}, Text: {2}", Id, Number, Text);
        }
    }
}