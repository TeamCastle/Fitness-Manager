namespace Fitness.Models.Diets
{
    public class RookieDiet : Diet
    {
        public RookieDiet(double kilos1, double height1, int age1, Sex sex1)
            : base(kilos1, height1, age1, sex1)
        {
        }

        protected override TypeDiet TypeOfDiet
        {
            get
            {
                return TypeDiet.RookieDiet;
            }
        }
    }
}