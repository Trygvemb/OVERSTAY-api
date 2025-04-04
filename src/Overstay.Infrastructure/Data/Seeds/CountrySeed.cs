using Microsoft.EntityFrameworkCore;
using Overstay.Domain.Entities.Countries;

namespace Overstay.Infrastructure.Data.Seeds;

public static class CountrySeed
{
    public static void SeedCountries(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Country>()
            .HasData(
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Name = "Afghanistan",
                    IsoCode = "AFG",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Name = "Albania",
                    IsoCode = "ALB",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    Name = "Algeria",
                    IsoCode = "DZA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    Name = "Andorra",
                    IsoCode = "AND",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000005"),
                    Name = "Angola",
                    IsoCode = "AGO",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000006"),
                    Name = "Antigua and Barbuda",
                    IsoCode = "ATG",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000007"),
                    Name = "Argentina",
                    IsoCode = "ARG",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000008"),
                    Name = "Armenia",
                    IsoCode = "ARM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000009"),
                    Name = "Australia",
                    IsoCode = "AUS",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000010"),
                    Name = "Austria",
                    IsoCode = "AUT",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000011"),
                    Name = "Azerbaijan",
                    IsoCode = "AZE",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000012"),
                    Name = "Bahamas",
                    IsoCode = "BHS",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000013"),
                    Name = "Bahrain",
                    IsoCode = "BHR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000014"),
                    Name = "Bangladesh",
                    IsoCode = "BGD",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000015"),
                    Name = "Barbados",
                    IsoCode = "BRB",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000016"),
                    Name = "Belarus",
                    IsoCode = "BLR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000017"),
                    Name = "Belgium",
                    IsoCode = "BEL",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000018"),
                    Name = "Belize",
                    IsoCode = "BLZ",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000019"),
                    Name = "Benin",
                    IsoCode = "BEN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000020"),
                    Name = "Bhutan",
                    IsoCode = "BTN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000021"),
                    Name = "Bolivia",
                    IsoCode = "BOL",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000022"),
                    Name = "Bosnia and Herzegovina",
                    IsoCode = "BIH",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000023"),
                    Name = "Botswana",
                    IsoCode = "BWA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000024"),
                    Name = "Brazil",
                    IsoCode = "BRA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000025"),
                    Name = "Brunei",
                    IsoCode = "BRN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000026"),
                    Name = "Bulgaria",
                    IsoCode = "BGR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000027"),
                    Name = "Burkina Faso",
                    IsoCode = "BFA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000028"),
                    Name = "Burundi",
                    IsoCode = "BDI",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000029"),
                    Name = "Cambodia",
                    IsoCode = "KHM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000030"),
                    Name = "Cameroon",
                    IsoCode = "CMR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000031"),
                    Name = "Canada",
                    IsoCode = "CAN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000032"),
                    Name = "Cape Verde",
                    IsoCode = "CPV",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000033"),
                    Name = "Central African Republic",
                    IsoCode = "CAF",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000034"),
                    Name = "Chad",
                    IsoCode = "TCD",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000035"),
                    Name = "Chile",
                    IsoCode = "CHL",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000036"),
                    Name = "China",
                    IsoCode = "CHN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000037"),
                    Name = "Colombia",
                    IsoCode = "COL",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000038"),
                    Name = "Comoros",
                    IsoCode = "COM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000039"),
                    Name = "Congo",
                    IsoCode = "COG",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000040"),
                    Name = "Costa Rica",
                    IsoCode = "CRI",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000041"),
                    Name = "Croatia",
                    IsoCode = "HRV",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000042"),
                    Name = "Cuba",
                    IsoCode = "CUB",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000043"),
                    Name = "Cyprus",
                    IsoCode = "CYP",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000044"),
                    Name = "Czech Republic",
                    IsoCode = "CZE",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000045"),
                    Name = "Denmark",
                    IsoCode = "DNK",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000046"),
                    Name = "Djibouti",
                    IsoCode = "DJI",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000047"),
                    Name = "Dominica",
                    IsoCode = "DMA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000048"),
                    Name = "Dominican Republic",
                    IsoCode = "DOM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000049"),
                    Name = "East Timor",
                    IsoCode = "TLS",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000050"),
                    Name = "Ecuador",
                    IsoCode = "ECU",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000051"),
                    Name = "Egypt",
                    IsoCode = "EGY",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000052"),
                    Name = "El Salvador",
                    IsoCode = "SLV",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000053"),
                    Name = "Equatorial Guinea",
                    IsoCode = "GNQ",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000054"),
                    Name = "Eritrea",
                    IsoCode = "ERI",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000055"),
                    Name = "Estonia",
                    IsoCode = "EST",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000056"),
                    Name = "Ethiopia",
                    IsoCode = "ETH",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000057"),
                    Name = "Fiji",
                    IsoCode = "FJI",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000058"),
                    Name = "Finland",
                    IsoCode = "FIN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000059"),
                    Name = "France",
                    IsoCode = "FRA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000060"),
                    Name = "Gabon",
                    IsoCode = "GAB",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000061"),
                    Name = "Gambia",
                    IsoCode = "GMB",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000062"),
                    Name = "Georgia",
                    IsoCode = "GEO",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000063"),
                    Name = "Germany",
                    IsoCode = "DEU",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000064"),
                    Name = "Ghana",
                    IsoCode = "GHA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000065"),
                    Name = "Greece",
                    IsoCode = "GRC",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000066"),
                    Name = "Grenada",
                    IsoCode = "GRD",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000067"),
                    Name = "Guatemala",
                    IsoCode = "GTM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000068"),
                    Name = "Guinea",
                    IsoCode = "GIN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000069"),
                    Name = "Guinea-Bissau",
                    IsoCode = "GNB",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000070"),
                    Name = "Guyana",
                    IsoCode = "GUY",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000071"),
                    Name = "Haiti",
                    IsoCode = "HTI",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000072"),
                    Name = "Honduras",
                    IsoCode = "HND",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000073"),
                    Name = "Hungary",
                    IsoCode = "HUN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000074"),
                    Name = "Iceland",
                    IsoCode = "ISL",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000075"),
                    Name = "India",
                    IsoCode = "IND",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000076"),
                    Name = "Indonesia",
                    IsoCode = "IDN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000077"),
                    Name = "Iran",
                    IsoCode = "IRN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000078"),
                    Name = "Iraq",
                    IsoCode = "IRQ",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000079"),
                    Name = "Ireland",
                    IsoCode = "IRL",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000080"),
                    Name = "Israel",
                    IsoCode = "ISR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000081"),
                    Name = "Italy",
                    IsoCode = "ITA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000082"),
                    Name = "Jamaica",
                    IsoCode = "JAM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000083"),
                    Name = "Japan",
                    IsoCode = "JPN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000084"),
                    Name = "Jordan",
                    IsoCode = "JOR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000085"),
                    Name = "Kazakhstan",
                    IsoCode = "KAZ",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000086"),
                    Name = "Kenya",
                    IsoCode = "KEN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000087"),
                    Name = "Kiribati",
                    IsoCode = "KIR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000088"),
                    Name = "North Korea",
                    IsoCode = "PRK",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000089"),
                    Name = "South Korea",
                    IsoCode = "KOR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000090"),
                    Name = "Kuwait",
                    IsoCode = "KWT",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000091"),
                    Name = "Kyrgyzstan",
                    IsoCode = "KGZ",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000092"),
                    Name = "Laos",
                    IsoCode = "LAO",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000093"),
                    Name = "Latvia",
                    IsoCode = "LVA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000094"),
                    Name = "Lebanon",
                    IsoCode = "LBN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000095"),
                    Name = "Lesotho",
                    IsoCode = "LSO",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000096"),
                    Name = "Liberia",
                    IsoCode = "LBR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000097"),
                    Name = "Libya",
                    IsoCode = "LBY",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000098"),
                    Name = "Liechtenstein",
                    IsoCode = "LIE",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000099"),
                    Name = "Lithuania",
                    IsoCode = "LTU",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000100"),
                    Name = "Luxembourg",
                    IsoCode = "LUX",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000101"),
                    Name = "Madagascar",
                    IsoCode = "MDG",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000102"),
                    Name = "Malawi",
                    IsoCode = "MWI",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000103"),
                    Name = "Malaysia",
                    IsoCode = "MYS",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000104"),
                    Name = "Maldives",
                    IsoCode = "MDV",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000105"),
                    Name = "Mali",
                    IsoCode = "MLI",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000106"),
                    Name = "Malta",
                    IsoCode = "MLT",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000107"),
                    Name = "Marshall Islands",
                    IsoCode = "MHL",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000108"),
                    Name = "Mauritania",
                    IsoCode = "MRT",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000109"),
                    Name = "Mauritius",
                    IsoCode = "MUS",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000110"),
                    Name = "Mexico",
                    IsoCode = "MEX",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000111"),
                    Name = "Micronesia",
                    IsoCode = "FSM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000112"),
                    Name = "Moldova",
                    IsoCode = "MDA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000113"),
                    Name = "Monaco",
                    IsoCode = "MCO",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000114"),
                    Name = "Mongolia",
                    IsoCode = "MNG",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000115"),
                    Name = "Montenegro",
                    IsoCode = "MNE",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000116"),
                    Name = "Morocco",
                    IsoCode = "MAR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000117"),
                    Name = "Mozambique",
                    IsoCode = "MOZ",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000118"),
                    Name = "Myanmar",
                    IsoCode = "MMR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000119"),
                    Name = "Namibia",
                    IsoCode = "NAM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000120"),
                    Name = "Nauru",
                    IsoCode = "NRU",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000121"),
                    Name = "Nepal",
                    IsoCode = "NPL",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000122"),
                    Name = "Netherlands",
                    IsoCode = "NLD",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000123"),
                    Name = "New Zealand",
                    IsoCode = "NZL",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000124"),
                    Name = "Nicaragua",
                    IsoCode = "NIC",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000125"),
                    Name = "Niger",
                    IsoCode = "NER",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000126"),
                    Name = "Nigeria",
                    IsoCode = "NGA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000127"),
                    Name = "North Macedonia",
                    IsoCode = "MKD",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000128"),
                    Name = "Norway",
                    IsoCode = "NOR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000129"),
                    Name = "Oman",
                    IsoCode = "OMN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000130"),
                    Name = "Pakistan",
                    IsoCode = "PAK",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000131"),
                    Name = "Palau",
                    IsoCode = "PLW",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000132"),
                    Name = "Palestine",
                    IsoCode = "PSE",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000133"),
                    Name = "Panama",
                    IsoCode = "PAN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000134"),
                    Name = "Papua New Guinea",
                    IsoCode = "PNG",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000135"),
                    Name = "Paraguay",
                    IsoCode = "PRY",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000136"),
                    Name = "Peru",
                    IsoCode = "PER",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000137"),
                    Name = "Philippines",
                    IsoCode = "PHL",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000138"),
                    Name = "Poland",
                    IsoCode = "POL",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000139"),
                    Name = "Portugal",
                    IsoCode = "PRT",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000140"),
                    Name = "Qatar",
                    IsoCode = "QAT",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000141"),
                    Name = "Romania",
                    IsoCode = "ROU",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000142"),
                    Name = "Russia",
                    IsoCode = "RUS",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000143"),
                    Name = "Rwanda",
                    IsoCode = "RWA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000144"),
                    Name = "Saint Kitts and Nevis",
                    IsoCode = "KNA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000145"),
                    Name = "Saint Lucia",
                    IsoCode = "LCA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000146"),
                    Name = "Saint Vincent and the Grenadines",
                    IsoCode = "VCT",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000147"),
                    Name = "Samoa",
                    IsoCode = "WSM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000148"),
                    Name = "San Marino",
                    IsoCode = "SMR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000149"),
                    Name = "Sao Tome and Principe",
                    IsoCode = "STP",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000150"),
                    Name = "Saudi Arabia",
                    IsoCode = "SAU",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000151"),
                    Name = "Senegal",
                    IsoCode = "SEN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000152"),
                    Name = "Serbia",
                    IsoCode = "SRB",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000153"),
                    Name = "Seychelles",
                    IsoCode = "SYC",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000154"),
                    Name = "Sierra Leone",
                    IsoCode = "SLE",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000155"),
                    Name = "Singapore",
                    IsoCode = "SGP",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000156"),
                    Name = "Slovakia",
                    IsoCode = "SVK",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000157"),
                    Name = "Slovenia",
                    IsoCode = "SVN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000158"),
                    Name = "Solomon Islands",
                    IsoCode = "SLB",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000159"),
                    Name = "Somalia",
                    IsoCode = "SOM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000160"),
                    Name = "South Africa",
                    IsoCode = "ZAF",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000161"),
                    Name = "South Sudan",
                    IsoCode = "SSD",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000162"),
                    Name = "Spain",
                    IsoCode = "ESP",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000163"),
                    Name = "Sri Lanka",
                    IsoCode = "LKA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000164"),
                    Name = "Sudan",
                    IsoCode = "SDN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000165"),
                    Name = "Suriname",
                    IsoCode = "SUR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000166"),
                    Name = "Sweden",
                    IsoCode = "SWE",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000167"),
                    Name = "Switzerland",
                    IsoCode = "CHE",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000168"),
                    Name = "Syria",
                    IsoCode = "SYR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000169"),
                    Name = "Taiwan",
                    IsoCode = "TWN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000170"),
                    Name = "Tajikistan",
                    IsoCode = "TJK",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000171"),
                    Name = "Tanzania",
                    IsoCode = "TZA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000172"),
                    Name = "Thailand",
                    IsoCode = "THA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000173"),
                    Name = "Togo",
                    IsoCode = "TGO",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000174"),
                    Name = "Tonga",
                    IsoCode = "TON",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000175"),
                    Name = "Trinidad and Tobago",
                    IsoCode = "TTO",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000176"),
                    Name = "Tunisia",
                    IsoCode = "TUN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000177"),
                    Name = "Turkey",
                    IsoCode = "TUR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000178"),
                    Name = "Turkmenistan",
                    IsoCode = "TKM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000179"),
                    Name = "Tuvalu",
                    IsoCode = "TUV",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000180"),
                    Name = "Uganda",
                    IsoCode = "UGA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000181"),
                    Name = "Ukraine",
                    IsoCode = "UKR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000182"),
                    Name = "United Arab Emirates",
                    IsoCode = "ARE",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000183"),
                    Name = "United Kingdom",
                    IsoCode = "GBR",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000184"),
                    Name = "United States",
                    IsoCode = "USA",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000185"),
                    Name = "Uruguay",
                    IsoCode = "URY",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000186"),
                    Name = "Uzbekistan",
                    IsoCode = "UZB",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000187"),
                    Name = "Vanuatu",
                    IsoCode = "VUT",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000188"),
                    Name = "Vatican City",
                    IsoCode = "VAT",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000189"),
                    Name = "Venezuela",
                    IsoCode = "VEN",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000190"),
                    Name = "Vietnam",
                    IsoCode = "VNM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000191"),
                    Name = "Yemen",
                    IsoCode = "YEM",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000192"),
                    Name = "Zambia",
                    IsoCode = "ZMB",
                },
                new Country
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000193"),
                    Name = "Zimbabwe",
                    IsoCode = "ZWE",
                }
            );
    }
}
