namespace _01._Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var hospital = new Dictionary<string,List<KeyValuePair<string,string>>>();
            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0]=="Output")
                {
                    break;
                }

                var department = input[0];
                var doctor = input[1] + " " + input[2];
                var patient = input[3];
                if (!hospital.ContainsKey(department))
                {
                    hospital.Add(department,new List<KeyValuePair<string, string>>());
                }

                if (hospital[department].Count<=60)
                {
                    hospital[department].Add(new KeyValuePair<string, string>(patient, doctor));
                    
                }
            }

            while (true)
            {
                var commandFilter = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandFilter[0]=="End")
                {
                    break;
                }

                if (commandFilter.Length == 1)
                {
                    foreach (var department in hospital.Where(x => x.Key == commandFilter[0]))
                    {
                        foreach (var patientAndDoctor in department.Value)
                        {
                           
                            Console.WriteLine(patientAndDoctor.Key);
                        }
                    }
                }

                else if (char.IsDigit(commandFilter[1][0]))
                {
                    var roomCounter = 0;
                    var department = commandFilter[0];
                    var room = int.Parse(commandFilter[1]);
                    var patientList = new SortedSet<string>();
                    foreach (var departmentAndDoctor in hospital.Where(x => x.Key == department))
                    {
                        foreach (var doctorAndPatient in departmentAndDoctor.Value)
                        {
                            roomCounter++;
                            if (roomCounter > (room - 1) * 3 && roomCounter <= (room - 1) * 3 + 3)
                            {
                                patientList.Add(doctorAndPatient.Key);
                            }
                        }
                    }

                    Console.WriteLine(string.Join(Environment.NewLine, patientList));
                }
                else
                {
                    var doctorName = commandFilter[0] + " " + commandFilter[1];
                    var patientList = new SortedSet<string>();
                    foreach (var departmentAndDoctor in hospital)
                    {
                        foreach (var patientAndDoctor in departmentAndDoctor.Value.OrderBy(x=>x.Key).Where(x => x.Value == doctorName))
                        {
                            patientList.Add(patientAndDoctor.Key);
                        }
                    }

                    Console.WriteLine(string.Join(Environment.NewLine,patientList));
                }
            }
        }
    }
}
