using System.ComponentModel.DataAnnotations;

namespace Interface
{
    public class CompileFinder : ValidationAttribute
    {
        public string CompileName { get; set; }

        public CompileFinder(string CompileName)
        {
            this.CompileName = CompileName;
        }

        public override bool IsValid(object value)
        {
            return true;
        }
    }
}
