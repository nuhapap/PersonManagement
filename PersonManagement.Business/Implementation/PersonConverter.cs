using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PersonManagement.Business.Contracts.Models;

namespace PersonManagement.Business.Implementation
{
    public static class PersonConverter
    {
        public static PersonDto ConvertFromString(string line, List<ColorDto> availableColors)
        {
            if (!IsValidLine(line))
            {
                return null;
            }

            var person = GetPerson(line, availableColors);
            return person;
        }

        private static bool IsValidLine(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return false;
            }

            // Müller, Hans, 67742 Lauterecken, 1
            // \w+   ,\s\w+,\s\d+\s\w+        ,\s\d+

            var validationPattern = @"[^,]+,\s[^,]+,\s\d+\s[^,]+,\s\d+";
            var regex = new Regex(validationPattern);
            var match = regex.Match(line);
            if (!match.Success)
            {
                return false;
            }

            return true;
        }

        private static PersonDto GetPerson(string line, List<ColorDto> availableColors)
        {
            // Müller, Hans, 67742 Lauterecken, 1
            var pattern = @"(?<LastName>[^,]+),\s(?<Name>[^,]+),\s(?<Zipcode>\d+)\s(?<City>[^,]+),\s(?<ColorId>\d+)";

            var regex = new Regex(pattern);
            var match = regex.Match(line);
            if (!match.Success)
            {
                return null;
            }

            var lastName = match.Groups["LastName"];
            var name = match.Groups["Name"];
            var zipcode = match.Groups["Zipcode"];
            var city = match.Groups["City"];
            var colorId = match.Groups["ColorId"];

            if (!int.TryParse(zipcode.Value, out _) || !int.TryParse(colorId.Value, out var colorIdNumber))
            {
                return null;
            }

            var availableColorIds = availableColors.Select(x => x.Id);
            if (!availableColorIds.Contains(colorIdNumber))
            {
                return null;
            }

            var matchingColor = availableColors.First(x => x.Id == colorIdNumber);
            var person = new PersonDto
            {
                LastName = lastName.Value,
                Name = name.Value,
                City = city.Value,
                Zipcode = zipcode.Value,
                ColorId = matchingColor.Id,
                Color = new ColorDto
                {
                    Id = matchingColor.Id,
                    Name = matchingColor.Name
                }
            };

            return person;
        }
    }
}