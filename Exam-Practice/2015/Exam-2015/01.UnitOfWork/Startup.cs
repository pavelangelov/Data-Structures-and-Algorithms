using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.UnitOfWork
{
    class Startup
    {
        static Dictionary<string, Unit> unitsByName = new Dictionary<string, Unit>();
        static SortedSet<Unit> unitsByAttack = new SortedSet<Unit>();

        static void Main()
        {
            var line = Console.ReadLine();
            var result = new StringBuilder();

            // only "end" command starts with 'e'
            while (line[0] != 'e')
            {
                var cmd = ExtractCommand(line);
                var msg = "";
                switch (cmd.Name)
                {
                    case "add":
                        msg = AddUnit(cmd.Arguments);
                        break;
                    case "power":
                        var numberOfUnits = int.Parse(cmd.Arguments[0]);
                        msg = Power(numberOfUnits);
                        break;
                    case "find":
                        var type = cmd.Arguments[0];
                        msg = FindByType(type);
                        break;
                    case "remove":
                        var unitName = cmd.Arguments[0];
                        msg = RemoveUnit(unitName);
                        break;
                    default:
                        Console.WriteLine("Invalid command parameters!");
                        break;
                }

                result.AppendLine(msg); ;
                line = Console.ReadLine();
            }

            Console.WriteLine(result.ToString().Trim());
        }

        static string AddUnit(IList<string> arguments)
        {
            var unitName = arguments[0];
            var unitType = arguments[1];
            var unitAttack = int.Parse(arguments[2]);
            var unit = new Unit(unitName, unitType, unitAttack);

            if (unitsByName.ContainsKey(unitName))
            {
                return string.Format("FAIL: {0} already exists!", unitName);
            }

            unitsByName.Add(unitName, unit);
            unitsByAttack.Add(unit);
            return string.Format("SUCCESS: {0} added!", unitName);
        }

        static string Power(int topUnits)
        {
            var unitsByPower = unitsByAttack.Take(topUnits);
            return string.Format("RESULT: {0}", string.Join(", ", unitsByPower));
        }

        static string FindByType(string type)
        {
            var unitsByType = unitsByAttack.Where(x => x.Type == type)
                                            .Take(10)
                                            .OrderByDescending(x => x.Attack)
                                            .ThenBy(x => x.Name);
            return string.Format("RESULT: {0}", string.Join(", ", unitsByType));
        }

        static string RemoveUnit(string unitName)
        {
            if (!unitsByName.ContainsKey(unitName))
            {
                return string.Format("FAIL: {0} could not be found!", unitName);
            }

            var unit = unitsByName[unitName];
            unitsByName.Remove(unitName);
            unitsByAttack.Remove(unit);

            return string.Format("SUCCESS: {0} removed!", unitName);
        }

        static Command ExtractCommand(string text)
        {
            var cmd = text.Split(' ');
            var name = cmd[0];
            var argsLen = cmd.Length - 1;
            var args = new string[argsLen];
            Array.Copy(cmd, 1, args, 0, argsLen);

            var command = new Command(name, args);

            return command;
        }

        class Command
        {
            public Command(string name, IList<string> args)
            {
                this.Name = name;
                this.Arguments = args;
            }

            public string Name { get; set; }

            public IList<string> Arguments { get; set; }
        }

        class Unit : IComparable<Unit>
        {
            public Unit(string name, string type, int attack)
            {
                this.Name = name;
                this.Type = type;
                this.Attack = attack;
            }

            public string Name { get; set; }

            public string Type { get; set; }

            public int Attack { get; set; }

            public override string ToString()
            {
                return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
            }

            public int CompareTo(Unit other)
            {
                int compare;
                if (this.Attack.CompareTo(other.Attack) != 0)
                {
                    compare = this.Attack.CompareTo(other.Attack) * -1;
                }
                else
                {
                    compare = this.Name.CompareTo(other.Name);
                }

                return compare;
            }
        }
    }
}
