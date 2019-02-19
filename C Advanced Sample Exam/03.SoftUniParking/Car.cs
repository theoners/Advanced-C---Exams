namespace SoftUniParking
{
    using System.Text;

    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            var carInfo = new StringBuilder();
            carInfo.AppendLine($"Make: {this.Make}");
            carInfo.AppendLine($"Model: {this.Model}");
            carInfo.AppendLine($"HorsePower: {this.HorsePower}");
            carInfo.Append($"RegistrationNumber: {this.RegistrationNumber}");

            return carInfo.ToString();
        }
    }
}
