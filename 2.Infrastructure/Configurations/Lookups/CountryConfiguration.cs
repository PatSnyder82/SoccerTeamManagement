using Core.Models.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Abstractions;

namespace Infrastructure.Configuration.Lookups
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>, ISeed<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Relationships

            builder.HasMany(x => x.States)
                   .WithOne(x => x.Country);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<Country> builder)
        {
            //ISO 3166 values as of Feb 2022
            builder.HasData(new Country { Id = 1, Text = "Afghanistan", Alpha2Code = "AF", Alpha3Code = "AFG", Value = "4", SortOrder = 4, IsDisabled = false });
            builder.HasData(new Country { Id = 2, Text = "Albania", Alpha2Code = "AL", Alpha3Code = "ALB", Value = "8", SortOrder = 8, IsDisabled = false });
            builder.HasData(new Country { Id = 3, Text = "Algeria", Alpha2Code = "DZ", Alpha3Code = "DZA", Value = "12", SortOrder = 12, IsDisabled = false });
            builder.HasData(new Country { Id = 4, Text = "American Samoa", Alpha2Code = "AS", Alpha3Code = "ASM", Value = "16", SortOrder = 16, IsDisabled = false });
            builder.HasData(new Country { Id = 5, Text = "Andorra", Alpha2Code = "AD", Alpha3Code = "AND", Value = "20", SortOrder = 20, IsDisabled = false });
            builder.HasData(new Country { Id = 6, Text = "Angola", Alpha2Code = "AO", Alpha3Code = "AGO", Value = "24", SortOrder = 24, IsDisabled = false });
            builder.HasData(new Country { Id = 7, Text = "Anguilla", Alpha2Code = "AI", Alpha3Code = "AIA", Value = "660", SortOrder = 660, IsDisabled = false });
            builder.HasData(new Country { Id = 8, Text = "Antarctica", Alpha2Code = "AQ", Alpha3Code = "ATA", Value = "10", SortOrder = 10, IsDisabled = false });
            builder.HasData(new Country { Id = 9, Text = "Antigua and Barbuda", Alpha2Code = "AG", Alpha3Code = "ATG", Value = "28", SortOrder = 28, IsDisabled = false });
            builder.HasData(new Country { Id = 10, Text = "Argentina", Alpha2Code = "AR", Alpha3Code = "ARG", Value = "32", SortOrder = 32, IsDisabled = false });
            builder.HasData(new Country { Id = 11, Text = "Armenia", Alpha2Code = "AM", Alpha3Code = "ARM", Value = "51", SortOrder = 51, IsDisabled = false });
            builder.HasData(new Country { Id = 12, Text = "Aruba", Alpha2Code = "AW", Alpha3Code = "ABW", Value = "533", SortOrder = 533, IsDisabled = false });
            builder.HasData(new Country { Id = 13, Text = "Australia", Alpha2Code = "AU", Alpha3Code = "AUS", Value = "36", SortOrder = 36, IsDisabled = false });
            builder.HasData(new Country { Id = 14, Text = "Austria", Alpha2Code = "AT", Alpha3Code = "AUT", Value = "40", SortOrder = 40, IsDisabled = false });
            builder.HasData(new Country { Id = 15, Text = "Azerbaijan", Alpha2Code = "AZ", Alpha3Code = "AZE", Value = "31", SortOrder = 31, IsDisabled = false });
            builder.HasData(new Country { Id = 16, Text = "Bahamas", Alpha2Code = "BS", Alpha3Code = "BHS", Value = "44", SortOrder = 44, IsDisabled = false });
            builder.HasData(new Country { Id = 17, Text = "Bahrain", Alpha2Code = "BH", Alpha3Code = "BHR", Value = "48", SortOrder = 48, IsDisabled = false });
            builder.HasData(new Country { Id = 18, Text = "Bangladesh", Alpha2Code = "BD", Alpha3Code = "BGD", Value = "50", SortOrder = 50, IsDisabled = false });
            builder.HasData(new Country { Id = 19, Text = "Barbados", Alpha2Code = "BB", Alpha3Code = "BRB", Value = "52", SortOrder = 52, IsDisabled = false });
            builder.HasData(new Country { Id = 20, Text = "Belarus", Alpha2Code = "BY", Alpha3Code = "BLR", Value = "112", SortOrder = 112, IsDisabled = false });
            builder.HasData(new Country { Id = 21, Text = "Belgium", Alpha2Code = "BE", Alpha3Code = "BEL", Value = "56", SortOrder = 56, IsDisabled = false });
            builder.HasData(new Country { Id = 22, Text = "Belize", Alpha2Code = "BZ", Alpha3Code = "BLZ", Value = "84", SortOrder = 84, IsDisabled = false });
            builder.HasData(new Country { Id = 23, Text = "Benin", Alpha2Code = "BJ", Alpha3Code = "BEN", Value = "204", SortOrder = 204, IsDisabled = false });
            builder.HasData(new Country { Id = 24, Text = "Bermuda", Alpha2Code = "BM", Alpha3Code = "BMU", Value = "60", SortOrder = 60, IsDisabled = false });
            builder.HasData(new Country { Id = 25, Text = "Åland Islands", Alpha2Code = "AX", Alpha3Code = "ALA", Value = "248", SortOrder = 248, IsDisabled = false });
            builder.HasData(new Country { Id = 26, Text = "Bhutan", Alpha2Code = "BT", Alpha3Code = "BTN", Value = "64", SortOrder = 64, IsDisabled = false });
            builder.HasData(new Country { Id = 27, Text = "Bolivia (Plurinational State of)", Alpha2Code = "BO", Alpha3Code = "BOL", Value = "68", SortOrder = 68, IsDisabled = false });
            builder.HasData(new Country { Id = 28, Text = "Bonaire, Sint Eustatius and Saba", Alpha2Code = "BQ", Alpha3Code = "BES", Value = "535", SortOrder = 535, IsDisabled = false });
            builder.HasData(new Country { Id = 29, Text = "Bosnia and Herzegovina", Alpha2Code = "BA", Alpha3Code = "BIH", Value = "70", SortOrder = 70, IsDisabled = false });
            builder.HasData(new Country { Id = 30, Text = "Botswana", Alpha2Code = "BW", Alpha3Code = "BWA", Value = "72", SortOrder = 72, IsDisabled = false });
            builder.HasData(new Country { Id = 31, Text = "Bouvet Island", Alpha2Code = "BV", Alpha3Code = "BVT", Value = "74", SortOrder = 74, IsDisabled = false });
            builder.HasData(new Country { Id = 32, Text = "Brazil", Alpha2Code = "BR", Alpha3Code = "BRA", Value = "76", SortOrder = 76, IsDisabled = false });
            builder.HasData(new Country { Id = 33, Text = "British Indian Ocean Territory", Alpha2Code = "IO", Alpha3Code = "IOT", Value = "86", SortOrder = 86, IsDisabled = false });
            builder.HasData(new Country { Id = 34, Text = "Brunei Darussalam", Alpha2Code = "BN", Alpha3Code = "BRN", Value = "96", SortOrder = 96, IsDisabled = false });
            builder.HasData(new Country { Id = 35, Text = "Bulgaria", Alpha2Code = "BG", Alpha3Code = "BGR", Value = "100", SortOrder = 100, IsDisabled = false });
            builder.HasData(new Country { Id = 36, Text = "Burkina Faso", Alpha2Code = "BF", Alpha3Code = "BFA", Value = "854", SortOrder = 854, IsDisabled = false });
            builder.HasData(new Country { Id = 37, Text = "Burundi", Alpha2Code = "BI", Alpha3Code = "BDI", Value = "108", SortOrder = 108, IsDisabled = false });
            builder.HasData(new Country { Id = 38, Text = "Cabo Verde", Alpha2Code = "CV", Alpha3Code = "CPV", Value = "132", SortOrder = 132, IsDisabled = false });
            builder.HasData(new Country { Id = 39, Text = "Cambodia", Alpha2Code = "KH", Alpha3Code = "KHM", Value = "116", SortOrder = 116, IsDisabled = false });
            builder.HasData(new Country { Id = 40, Text = "Cameroon", Alpha2Code = "CM", Alpha3Code = "CMR", Value = "120", SortOrder = 120, IsDisabled = false });
            builder.HasData(new Country { Id = 41, Text = "Canada", Alpha2Code = "CA", Alpha3Code = "CAN", Value = "124", SortOrder = 124, IsDisabled = false });
            builder.HasData(new Country { Id = 42, Text = "Cayman Islands", Alpha2Code = "KY", Alpha3Code = "CYM", Value = "136", SortOrder = 136, IsDisabled = false });
            builder.HasData(new Country { Id = 43, Text = "Central African Republic", Alpha2Code = "CF", Alpha3Code = "CAF", Value = "140", SortOrder = 140, IsDisabled = false });
            builder.HasData(new Country { Id = 44, Text = "Chad", Alpha2Code = "TD", Alpha3Code = "TCD", Value = "148", SortOrder = 148, IsDisabled = false });
            builder.HasData(new Country { Id = 45, Text = "Chile", Alpha2Code = "CL", Alpha3Code = "CHL", Value = "152", SortOrder = 152, IsDisabled = false });
            builder.HasData(new Country { Id = 46, Text = "China", Alpha2Code = "CN", Alpha3Code = "CHN", Value = "156", SortOrder = 156, IsDisabled = false });
            builder.HasData(new Country { Id = 47, Text = "Christmas Island", Alpha2Code = "CX", Alpha3Code = "CXR", Value = "162", SortOrder = 162, IsDisabled = false });
            builder.HasData(new Country { Id = 48, Text = "Cocos (Keeling) Islands", Alpha2Code = "CC", Alpha3Code = "CCK", Value = "166", SortOrder = 166, IsDisabled = false });
            builder.HasData(new Country { Id = 49, Text = "Colombia", Alpha2Code = "CO", Alpha3Code = "COL", Value = "170", SortOrder = 170, IsDisabled = false });
            builder.HasData(new Country { Id = 50, Text = "Comoros", Alpha2Code = "KM", Alpha3Code = "COM", Value = "174", SortOrder = 174, IsDisabled = false });
            builder.HasData(new Country { Id = 51, Text = "Congo (the Democratic Republic of the)", Alpha2Code = "CD", Alpha3Code = "COD", Value = "180", SortOrder = 180, IsDisabled = false });
            builder.HasData(new Country { Id = 52, Text = "Congo", Alpha2Code = "CG", Alpha3Code = "COG", Value = "178", SortOrder = 178, IsDisabled = false });
            builder.HasData(new Country { Id = 53, Text = "Cook Islands", Alpha2Code = "CK", Alpha3Code = "COK", Value = "184", SortOrder = 184, IsDisabled = false });
            builder.HasData(new Country { Id = 54, Text = "Costa Rica", Alpha2Code = "CR", Alpha3Code = "CRI", Value = "188", SortOrder = 188, IsDisabled = false });
            builder.HasData(new Country { Id = 55, Text = "Croatia", Alpha2Code = "HR", Alpha3Code = "HRV", Value = "191", SortOrder = 191, IsDisabled = false });
            builder.HasData(new Country { Id = 56, Text = "Cuba", Alpha2Code = "CU", Alpha3Code = "CUB", Value = "192", SortOrder = 192, IsDisabled = false });
            builder.HasData(new Country { Id = 57, Text = "Curaçao", Alpha2Code = "CW", Alpha3Code = "CUW", Value = "531", SortOrder = 531, IsDisabled = false });
            builder.HasData(new Country { Id = 58, Text = "Cyprus", Alpha2Code = "CY", Alpha3Code = "CYP", Value = "196", SortOrder = 196, IsDisabled = false });
            builder.HasData(new Country { Id = 59, Text = "Czechia", Alpha2Code = "CZ", Alpha3Code = "CZE", Value = "203", SortOrder = 203, IsDisabled = false });
            builder.HasData(new Country { Id = 60, Text = "Côte d'Ivoire", Alpha2Code = "CI", Alpha3Code = "CIV", Value = "384", SortOrder = 384, IsDisabled = false });
            builder.HasData(new Country { Id = 61, Text = "Denmark", Alpha2Code = "DK", Alpha3Code = "DNK", Value = "208", SortOrder = 208, IsDisabled = false });
            builder.HasData(new Country { Id = 62, Text = "Djibouti", Alpha2Code = "DJ", Alpha3Code = "DJI", Value = "262", SortOrder = 262, IsDisabled = false });
            builder.HasData(new Country { Id = 63, Text = "Dominica", Alpha2Code = "DM", Alpha3Code = "DMA", Value = "212", SortOrder = 212, IsDisabled = false });
            builder.HasData(new Country { Id = 64, Text = "Dominican Republic", Alpha2Code = "DO", Alpha3Code = "DOM", Value = "214", SortOrder = 214, IsDisabled = false });
            builder.HasData(new Country { Id = 65, Text = "Ecuador", Alpha2Code = "EC", Alpha3Code = "ECU", Value = "218", SortOrder = 218, IsDisabled = false });
            builder.HasData(new Country { Id = 66, Text = "Egypt", Alpha2Code = "EG", Alpha3Code = "EGY", Value = "818", SortOrder = 818, IsDisabled = false });
            builder.HasData(new Country { Id = 67, Text = "El Salvador", Alpha2Code = "SV", Alpha3Code = "SLV", Value = "222", SortOrder = 222, IsDisabled = false });
            builder.HasData(new Country { Id = 68, Text = "Equatorial Guinea", Alpha2Code = "GQ", Alpha3Code = "GNQ", Value = "226", SortOrder = 226, IsDisabled = false });
            builder.HasData(new Country { Id = 69, Text = "Eritrea", Alpha2Code = "ER", Alpha3Code = "ERI", Value = "232", SortOrder = 232, IsDisabled = false });
            builder.HasData(new Country { Id = 70, Text = "Estonia", Alpha2Code = "EE", Alpha3Code = "EST", Value = "233", SortOrder = 233, IsDisabled = false });
            builder.HasData(new Country { Id = 71, Text = "Eswatini", Alpha2Code = "SZ", Alpha3Code = "SWZ", Value = "748", SortOrder = 748, IsDisabled = false });
            builder.HasData(new Country { Id = 72, Text = "Ethiopia", Alpha2Code = "ET", Alpha3Code = "ETH", Value = "231", SortOrder = 231, IsDisabled = false });
            builder.HasData(new Country { Id = 73, Text = "Falkland Islands [Malvinas]", Alpha2Code = "FK", Alpha3Code = "FLK", Value = "238", SortOrder = 238, IsDisabled = false });
            builder.HasData(new Country { Id = 74, Text = "Faroe Islands", Alpha2Code = "FO", Alpha3Code = "FRO", Value = "234", SortOrder = 234, IsDisabled = false });
            builder.HasData(new Country { Id = 75, Text = "Fiji", Alpha2Code = "FJ", Alpha3Code = "FJI", Value = "242", SortOrder = 242, IsDisabled = false });
            builder.HasData(new Country { Id = 76, Text = "Finland", Alpha2Code = "FI", Alpha3Code = "FIN", Value = "246", SortOrder = 246, IsDisabled = false });
            builder.HasData(new Country { Id = 77, Text = "France", Alpha2Code = "FR", Alpha3Code = "FRA", Value = "250", SortOrder = 250, IsDisabled = false });
            builder.HasData(new Country { Id = 78, Text = "French Guiana", Alpha2Code = "GF", Alpha3Code = "GUF", Value = "254", SortOrder = 254, IsDisabled = false });
            builder.HasData(new Country { Id = 79, Text = "French Polynesia", Alpha2Code = "PF", Alpha3Code = "PYF", Value = "258", SortOrder = 258, IsDisabled = false });
            builder.HasData(new Country { Id = 80, Text = "French Southern Territories", Alpha2Code = "TF", Alpha3Code = "ATF", Value = "260", SortOrder = 260, IsDisabled = false });
            builder.HasData(new Country { Id = 81, Text = "Gabon", Alpha2Code = "GA", Alpha3Code = "GAB", Value = "266", SortOrder = 266, IsDisabled = false });
            builder.HasData(new Country { Id = 82, Text = "Gambia", Alpha2Code = "GM", Alpha3Code = "GMB", Value = "270", SortOrder = 270, IsDisabled = false });
            builder.HasData(new Country { Id = 83, Text = "Georgia", Alpha2Code = "GE", Alpha3Code = "GEO", Value = "268", SortOrder = 268, IsDisabled = false });
            builder.HasData(new Country { Id = 84, Text = "Germany", Alpha2Code = "DE", Alpha3Code = "DEU", Value = "276", SortOrder = 276, IsDisabled = false });
            builder.HasData(new Country { Id = 85, Text = "Ghana", Alpha2Code = "GH", Alpha3Code = "GHA", Value = "288", SortOrder = 288, IsDisabled = false });
            builder.HasData(new Country { Id = 86, Text = "Gibraltar", Alpha2Code = "GI", Alpha3Code = "GIB", Value = "292", SortOrder = 292, IsDisabled = false });
            builder.HasData(new Country { Id = 87, Text = "Greece", Alpha2Code = "GR", Alpha3Code = "GRC", Value = "300", SortOrder = 300, IsDisabled = false });
            builder.HasData(new Country { Id = 88, Text = "Greenland", Alpha2Code = "GL", Alpha3Code = "GRL", Value = "304", SortOrder = 304, IsDisabled = false });
            builder.HasData(new Country { Id = 89, Text = "Grenada", Alpha2Code = "GD", Alpha3Code = "GRD", Value = "308", SortOrder = 308, IsDisabled = false });
            builder.HasData(new Country { Id = 90, Text = "Guadeloupe", Alpha2Code = "GP", Alpha3Code = "GLP", Value = "312", SortOrder = 312, IsDisabled = false });
            builder.HasData(new Country { Id = 91, Text = "Guam", Alpha2Code = "GU", Alpha3Code = "GUM", Value = "316", SortOrder = 316, IsDisabled = false });
            builder.HasData(new Country { Id = 92, Text = "Guatemala", Alpha2Code = "GT", Alpha3Code = "GTM", Value = "320", SortOrder = 320, IsDisabled = false });
            builder.HasData(new Country { Id = 93, Text = "Guernsey", Alpha2Code = "GG", Alpha3Code = "GGY", Value = "831", SortOrder = 831, IsDisabled = false });
            builder.HasData(new Country { Id = 94, Text = "Guinea", Alpha2Code = "GN", Alpha3Code = "GIN", Value = "324", SortOrder = 324, IsDisabled = false });
            builder.HasData(new Country { Id = 95, Text = "Guinea-Bissau", Alpha2Code = "GW", Alpha3Code = "GNB", Value = "624", SortOrder = 624, IsDisabled = false });
            builder.HasData(new Country { Id = 96, Text = "Guyana", Alpha2Code = "GY", Alpha3Code = "GUY", Value = "328", SortOrder = 328, IsDisabled = false });
            builder.HasData(new Country { Id = 97, Text = "Haiti", Alpha2Code = "HT", Alpha3Code = "HTI", Value = "332", SortOrder = 332, IsDisabled = false });
            builder.HasData(new Country { Id = 98, Text = "Heard Island and McDonald Islands", Alpha2Code = "HM", Alpha3Code = "HMD", Value = "334", SortOrder = 334, IsDisabled = false });
            builder.HasData(new Country { Id = 99, Text = "Holy See", Alpha2Code = "VA", Alpha3Code = "VAT", Value = "336", SortOrder = 336, IsDisabled = false });
            builder.HasData(new Country { Id = 100, Text = "Honduras", Alpha2Code = "HN", Alpha3Code = "HND", Value = "340", SortOrder = 340, IsDisabled = false });
            builder.HasData(new Country { Id = 101, Text = "Hong Kong", Alpha2Code = "HK", Alpha3Code = "HKG", Value = "344", SortOrder = 344, IsDisabled = false });
            builder.HasData(new Country { Id = 102, Text = "Hungary", Alpha2Code = "HU", Alpha3Code = "HUN", Value = "348", SortOrder = 348, IsDisabled = false });
            builder.HasData(new Country { Id = 103, Text = "Iceland", Alpha2Code = "IS", Alpha3Code = "ISL", Value = "352", SortOrder = 352, IsDisabled = false });
            builder.HasData(new Country { Id = 104, Text = "India", Alpha2Code = "IN", Alpha3Code = "IND", Value = "356", SortOrder = 356, IsDisabled = false });
            builder.HasData(new Country { Id = 105, Text = "Indonesia", Alpha2Code = "ID", Alpha3Code = "IDN", Value = "360", SortOrder = 360, IsDisabled = false });
            builder.HasData(new Country { Id = 106, Text = "Iran (Islamic Republic of)", Alpha2Code = "IR", Alpha3Code = "IRN", Value = "364", SortOrder = 364, IsDisabled = false });
            builder.HasData(new Country { Id = 107, Text = "Iraq", Alpha2Code = "IQ", Alpha3Code = "IRQ", Value = "368", SortOrder = 368, IsDisabled = false });
            builder.HasData(new Country { Id = 108, Text = "Ireland", Alpha2Code = "IE", Alpha3Code = "IRL", Value = "372", SortOrder = 372, IsDisabled = false });
            builder.HasData(new Country { Id = 109, Text = "Isle of Man", Alpha2Code = "IM", Alpha3Code = "IMN", Value = "833", SortOrder = 833, IsDisabled = false });
            builder.HasData(new Country { Id = 110, Text = "Israel", Alpha2Code = "IL", Alpha3Code = "ISR", Value = "376", SortOrder = 376, IsDisabled = false });
            builder.HasData(new Country { Id = 111, Text = "Italy", Alpha2Code = "IT", Alpha3Code = "ITA", Value = "380", SortOrder = 380, IsDisabled = false });
            builder.HasData(new Country { Id = 112, Text = "Jamaica", Alpha2Code = "JM", Alpha3Code = "JAM", Value = "388", SortOrder = 388, IsDisabled = false });
            builder.HasData(new Country { Id = 113, Text = "Japan", Alpha2Code = "JP", Alpha3Code = "JPN", Value = "392", SortOrder = 392, IsDisabled = false });
            builder.HasData(new Country { Id = 114, Text = "Jersey", Alpha2Code = "JE", Alpha3Code = "JEY", Value = "832", SortOrder = 832, IsDisabled = false });
            builder.HasData(new Country { Id = 115, Text = "Jordan", Alpha2Code = "JO", Alpha3Code = "JOR", Value = "400", SortOrder = 400, IsDisabled = false });
            builder.HasData(new Country { Id = 116, Text = "Kazakhstan", Alpha2Code = "KZ", Alpha3Code = "KAZ", Value = "398", SortOrder = 398, IsDisabled = false });
            builder.HasData(new Country { Id = 117, Text = "Kenya", Alpha2Code = "KE", Alpha3Code = "KEN", Value = "404", SortOrder = 404, IsDisabled = false });
            builder.HasData(new Country { Id = 118, Text = "Kiribati", Alpha2Code = "KI", Alpha3Code = "KIR", Value = "296", SortOrder = 296, IsDisabled = false });
            builder.HasData(new Country { Id = 119, Text = "Korea (the Democratic People's Republic of)", Alpha2Code = "KP", Alpha3Code = "PRK", Value = "408", SortOrder = 408, IsDisabled = false });
            builder.HasData(new Country { Id = 120, Text = "Korea (the Republic of)", Alpha2Code = "KR", Alpha3Code = "KOR", Value = "410", SortOrder = 410, IsDisabled = false });
            builder.HasData(new Country { Id = 121, Text = "Kuwait", Alpha2Code = "KW", Alpha3Code = "KWT", Value = "414", SortOrder = 414, IsDisabled = false });
            builder.HasData(new Country { Id = 122, Text = "Kyrgyzstan", Alpha2Code = "KG", Alpha3Code = "KGZ", Value = "417", SortOrder = 417, IsDisabled = false });
            builder.HasData(new Country { Id = 123, Text = "Lao People's Democratic Republic", Alpha2Code = "LA", Alpha3Code = "LAO", Value = "418", SortOrder = 418, IsDisabled = false });
            builder.HasData(new Country { Id = 124, Text = "Latvia", Alpha2Code = "LV", Alpha3Code = "LVA", Value = "428", SortOrder = 428, IsDisabled = false });
            builder.HasData(new Country { Id = 125, Text = "Lebanon", Alpha2Code = "LB", Alpha3Code = "LBN", Value = "422", SortOrder = 422, IsDisabled = false });
            builder.HasData(new Country { Id = 126, Text = "Lesotho", Alpha2Code = "LS", Alpha3Code = "LSO", Value = "426", SortOrder = 426, IsDisabled = false });
            builder.HasData(new Country { Id = 127, Text = "Liberia", Alpha2Code = "LR", Alpha3Code = "LBR", Value = "430", SortOrder = 430, IsDisabled = false });
            builder.HasData(new Country { Id = 128, Text = "Libya", Alpha2Code = "LY", Alpha3Code = "LBY", Value = "434", SortOrder = 434, IsDisabled = false });
            builder.HasData(new Country { Id = 129, Text = "Liechtenstein", Alpha2Code = "LI", Alpha3Code = "LIE", Value = "438", SortOrder = 438, IsDisabled = false });
            builder.HasData(new Country { Id = 130, Text = "Lithuania", Alpha2Code = "LT", Alpha3Code = "LTU", Value = "440", SortOrder = 440, IsDisabled = false });
            builder.HasData(new Country { Id = 131, Text = "Luxembourg", Alpha2Code = "LU", Alpha3Code = "LUX", Value = "442", SortOrder = 442, IsDisabled = false });
            builder.HasData(new Country { Id = 132, Text = "Macao", Alpha2Code = "MO", Alpha3Code = "MAC", Value = "446", SortOrder = 446, IsDisabled = false });
            builder.HasData(new Country { Id = 133, Text = "Madagascar", Alpha2Code = "MG", Alpha3Code = "MDG", Value = "450", SortOrder = 450, IsDisabled = false });
            builder.HasData(new Country { Id = 134, Text = "Malawi", Alpha2Code = "MW", Alpha3Code = "MWI", Value = "454", SortOrder = 454, IsDisabled = false });
            builder.HasData(new Country { Id = 135, Text = "Malaysia", Alpha2Code = "MY", Alpha3Code = "MYS", Value = "458", SortOrder = 458, IsDisabled = false });
            builder.HasData(new Country { Id = 136, Text = "Maldives", Alpha2Code = "MV", Alpha3Code = "MDV", Value = "462", SortOrder = 462, IsDisabled = false });
            builder.HasData(new Country { Id = 137, Text = "Mali", Alpha2Code = "ML", Alpha3Code = "MLI", Value = "466", SortOrder = 466, IsDisabled = false });
            builder.HasData(new Country { Id = 138, Text = "Malta", Alpha2Code = "MT", Alpha3Code = "MLT", Value = "470", SortOrder = 470, IsDisabled = false });
            builder.HasData(new Country { Id = 139, Text = "Marshall Islands", Alpha2Code = "MH", Alpha3Code = "MHL", Value = "584", SortOrder = 584, IsDisabled = false });
            builder.HasData(new Country { Id = 140, Text = "Martinique", Alpha2Code = "MQ", Alpha3Code = "MTQ", Value = "474", SortOrder = 474, IsDisabled = false });
            builder.HasData(new Country { Id = 141, Text = "Mauritania", Alpha2Code = "MR", Alpha3Code = "MRT", Value = "478", SortOrder = 478, IsDisabled = false });
            builder.HasData(new Country { Id = 142, Text = "Mauritius", Alpha2Code = "MU", Alpha3Code = "MUS", Value = "480", SortOrder = 480, IsDisabled = false });
            builder.HasData(new Country { Id = 143, Text = "Mayotte", Alpha2Code = "YT", Alpha3Code = "MYT", Value = "175", SortOrder = 175, IsDisabled = false });
            builder.HasData(new Country { Id = 144, Text = "Mexico", Alpha2Code = "MX", Alpha3Code = "MEX", Value = "484", SortOrder = 484, IsDisabled = false });
            builder.HasData(new Country { Id = 145, Text = "Micronesia (Federated States of)", Alpha2Code = "FM", Alpha3Code = "FSM", Value = "583", SortOrder = 583, IsDisabled = false });
            builder.HasData(new Country { Id = 146, Text = "Moldova (the Republic of)", Alpha2Code = "MD", Alpha3Code = "MDA", Value = "498", SortOrder = 498, IsDisabled = false });
            builder.HasData(new Country { Id = 147, Text = "Monaco", Alpha2Code = "MC", Alpha3Code = "MCO", Value = "492", SortOrder = 492, IsDisabled = false });
            builder.HasData(new Country { Id = 148, Text = "Mongolia", Alpha2Code = "MN", Alpha3Code = "MNG", Value = "496", SortOrder = 496, IsDisabled = false });
            builder.HasData(new Country { Id = 149, Text = "Montenegro", Alpha2Code = "ME", Alpha3Code = "MNE", Value = "499", SortOrder = 499, IsDisabled = false });
            builder.HasData(new Country { Id = 150, Text = "Montserrat", Alpha2Code = "MS", Alpha3Code = "MSR", Value = "500", SortOrder = 500, IsDisabled = false });
            builder.HasData(new Country { Id = 151, Text = "Morocco", Alpha2Code = "MA", Alpha3Code = "MAR", Value = "504", SortOrder = 504, IsDisabled = false });
            builder.HasData(new Country { Id = 152, Text = "Mozambique", Alpha2Code = "MZ", Alpha3Code = "MOZ", Value = "508", SortOrder = 508, IsDisabled = false });
            builder.HasData(new Country { Id = 153, Text = "Myanmar", Alpha2Code = "MM", Alpha3Code = "MMR", Value = "104", SortOrder = 104, IsDisabled = false });
            builder.HasData(new Country { Id = 154, Text = "Namibia", Alpha2Code = "NA", Alpha3Code = "NAM", Value = "516", SortOrder = 516, IsDisabled = false });
            builder.HasData(new Country { Id = 155, Text = "Nauru", Alpha2Code = "NR", Alpha3Code = "NRU", Value = "520", SortOrder = 520, IsDisabled = false });
            builder.HasData(new Country { Id = 156, Text = "Nepal", Alpha2Code = "NP", Alpha3Code = "NPL", Value = "524", SortOrder = 524, IsDisabled = false });
            builder.HasData(new Country { Id = 157, Text = "Netherlands", Alpha2Code = "NL", Alpha3Code = "NLD", Value = "528", SortOrder = 528, IsDisabled = false });
            builder.HasData(new Country { Id = 158, Text = "New Caledonia", Alpha2Code = "NC", Alpha3Code = "NCL", Value = "540", SortOrder = 540, IsDisabled = false });
            builder.HasData(new Country { Id = 159, Text = "New Zealand", Alpha2Code = "NZ", Alpha3Code = "NZL", Value = "554", SortOrder = 554, IsDisabled = false });
            builder.HasData(new Country { Id = 160, Text = "Nicaragua", Alpha2Code = "NI", Alpha3Code = "NIC", Value = "558", SortOrder = 558, IsDisabled = false });
            builder.HasData(new Country { Id = 161, Text = "Niger", Alpha2Code = "NE", Alpha3Code = "NER", Value = "562", SortOrder = 562, IsDisabled = false });
            builder.HasData(new Country { Id = 162, Text = "Nigeria", Alpha2Code = "NG", Alpha3Code = "NGA", Value = "566", SortOrder = 566, IsDisabled = false });
            builder.HasData(new Country { Id = 163, Text = "Niue", Alpha2Code = "NU", Alpha3Code = "NIU", Value = "570", SortOrder = 570, IsDisabled = false });
            builder.HasData(new Country { Id = 164, Text = "Norfolk Island", Alpha2Code = "NF", Alpha3Code = "NFK", Value = "574", SortOrder = 574, IsDisabled = false });
            builder.HasData(new Country { Id = 165, Text = "North Macedonia", Alpha2Code = "MK", Alpha3Code = "MKD", Value = "807", SortOrder = 807, IsDisabled = false });
            builder.HasData(new Country { Id = 166, Text = "Northern Mariana Islands", Alpha2Code = "MP", Alpha3Code = "MNP", Value = "580", SortOrder = 580, IsDisabled = false });
            builder.HasData(new Country { Id = 167, Text = "Norway", Alpha2Code = "NO", Alpha3Code = "NOR", Value = "578", SortOrder = 578, IsDisabled = false });
            builder.HasData(new Country { Id = 168, Text = "Oman", Alpha2Code = "OM", Alpha3Code = "OMN", Value = "512", SortOrder = 512, IsDisabled = false });
            builder.HasData(new Country { Id = 169, Text = "Pakistan", Alpha2Code = "PK", Alpha3Code = "PAK", Value = "586", SortOrder = 586, IsDisabled = false });
            builder.HasData(new Country { Id = 170, Text = "Palau", Alpha2Code = "PW", Alpha3Code = "PLW", Value = "585", SortOrder = 585, IsDisabled = false });
            builder.HasData(new Country { Id = 171, Text = "Palestine, State of", Alpha2Code = "PS", Alpha3Code = "PSE", Value = "275", SortOrder = 275, IsDisabled = false });
            builder.HasData(new Country { Id = 172, Text = "Panama", Alpha2Code = "PA", Alpha3Code = "PAN", Value = "591", SortOrder = 591, IsDisabled = false });
            builder.HasData(new Country { Id = 173, Text = "Papua New Guinea", Alpha2Code = "PG", Alpha3Code = "PNG", Value = "598", SortOrder = 598, IsDisabled = false });
            builder.HasData(new Country { Id = 174, Text = "Paraguay", Alpha2Code = "PY", Alpha3Code = "PRY", Value = "600", SortOrder = 600, IsDisabled = false });
            builder.HasData(new Country { Id = 175, Text = "Peru", Alpha2Code = "PE", Alpha3Code = "PER", Value = "604", SortOrder = 604, IsDisabled = false });
            builder.HasData(new Country { Id = 176, Text = "Philippines", Alpha2Code = "PH", Alpha3Code = "PHL", Value = "608", SortOrder = 608, IsDisabled = false });
            builder.HasData(new Country { Id = 177, Text = "Pitcairn", Alpha2Code = "PN", Alpha3Code = "PCN", Value = "612", SortOrder = 612, IsDisabled = false });
            builder.HasData(new Country { Id = 178, Text = "Poland", Alpha2Code = "PL", Alpha3Code = "POL", Value = "616", SortOrder = 616, IsDisabled = false });
            builder.HasData(new Country { Id = 179, Text = "Portugal", Alpha2Code = "PT", Alpha3Code = "PRT", Value = "620", SortOrder = 620, IsDisabled = false });
            builder.HasData(new Country { Id = 180, Text = "Puerto Rico", Alpha2Code = "PR", Alpha3Code = "PRI", Value = "630", SortOrder = 630, IsDisabled = false });
            builder.HasData(new Country { Id = 181, Text = "Qatar", Alpha2Code = "QA", Alpha3Code = "QAT", Value = "634", SortOrder = 634, IsDisabled = false });
            builder.HasData(new Country { Id = 182, Text = "Romania", Alpha2Code = "RO", Alpha3Code = "ROU", Value = "642", SortOrder = 642, IsDisabled = false });
            builder.HasData(new Country { Id = 183, Text = "Russian Federation", Alpha2Code = "RU", Alpha3Code = "RUS", Value = "643", SortOrder = 643, IsDisabled = false });
            builder.HasData(new Country { Id = 184, Text = "Rwanda", Alpha2Code = "RW", Alpha3Code = "RWA", Value = "646", SortOrder = 646, IsDisabled = false });
            builder.HasData(new Country { Id = 185, Text = "Réunion", Alpha2Code = "RE", Alpha3Code = "REU", Value = "638", SortOrder = 638, IsDisabled = false });
            builder.HasData(new Country { Id = 186, Text = "Saint Barthélemy", Alpha2Code = "BL", Alpha3Code = "BLM", Value = "652", SortOrder = 652, IsDisabled = false });
            builder.HasData(new Country { Id = 187, Text = "Saint Helena, Ascension and Tristan da Cunha", Alpha2Code = "SH", Alpha3Code = "SHN", Value = "654", SortOrder = 654, IsDisabled = false });
            builder.HasData(new Country { Id = 188, Text = "Saint Kitts and Nevis", Alpha2Code = "KN", Alpha3Code = "KNA", Value = "659", SortOrder = 659, IsDisabled = false });
            builder.HasData(new Country { Id = 189, Text = "Saint Lucia", Alpha2Code = "LC", Alpha3Code = "LCA", Value = "662", SortOrder = 662, IsDisabled = false });
            builder.HasData(new Country { Id = 190, Text = "Saint Martin (French part)", Alpha2Code = "MF", Alpha3Code = "MAF", Value = "663", SortOrder = 663, IsDisabled = false });
            builder.HasData(new Country { Id = 191, Text = "Saint Pierre and Miquelon", Alpha2Code = "PM", Alpha3Code = "SPM", Value = "666", SortOrder = 666, IsDisabled = false });
            builder.HasData(new Country { Id = 192, Text = "Saint Vincent and the Grenadines", Alpha2Code = "VC", Alpha3Code = "VCT", Value = "670", SortOrder = 670, IsDisabled = false });
            builder.HasData(new Country { Id = 193, Text = "Samoa", Alpha2Code = "WS", Alpha3Code = "WSM", Value = "882", SortOrder = 882, IsDisabled = false });
            builder.HasData(new Country { Id = 194, Text = "San Marino", Alpha2Code = "SM", Alpha3Code = "SMR", Value = "674", SortOrder = 674, IsDisabled = false });
            builder.HasData(new Country { Id = 195, Text = "Sao Tome and Principe", Alpha2Code = "ST", Alpha3Code = "STP", Value = "678", SortOrder = 678, IsDisabled = false });
            builder.HasData(new Country { Id = 196, Text = "Saudi Arabia", Alpha2Code = "SA", Alpha3Code = "SAU", Value = "682", SortOrder = 682, IsDisabled = false });
            builder.HasData(new Country { Id = 197, Text = "Senegal", Alpha2Code = "SN", Alpha3Code = "SEN", Value = "686", SortOrder = 686, IsDisabled = false });
            builder.HasData(new Country { Id = 198, Text = "Serbia", Alpha2Code = "RS", Alpha3Code = "SRB", Value = "688", SortOrder = 688, IsDisabled = false });
            builder.HasData(new Country { Id = 199, Text = "Seychelles", Alpha2Code = "SC", Alpha3Code = "SYC", Value = "690", SortOrder = 690, IsDisabled = false });
            builder.HasData(new Country { Id = 200, Text = "Sierra Leone", Alpha2Code = "SL", Alpha3Code = "SLE", Value = "694", SortOrder = 694, IsDisabled = false });
            builder.HasData(new Country { Id = 201, Text = "Singapore", Alpha2Code = "SG", Alpha3Code = "SGP", Value = "702", SortOrder = 702, IsDisabled = false });
            builder.HasData(new Country { Id = 202, Text = "Sint Maarten (Dutch part)", Alpha2Code = "SX", Alpha3Code = "SXM", Value = "534", SortOrder = 534, IsDisabled = false });
            builder.HasData(new Country { Id = 203, Text = "Slovakia", Alpha2Code = "SK", Alpha3Code = "SVK", Value = "703", SortOrder = 703, IsDisabled = false });
            builder.HasData(new Country { Id = 204, Text = "Slovenia", Alpha2Code = "SI", Alpha3Code = "SVN", Value = "705", SortOrder = 705, IsDisabled = false });
            builder.HasData(new Country { Id = 205, Text = "Solomon Islands", Alpha2Code = "SB", Alpha3Code = "SLB", Value = "90", SortOrder = 90, IsDisabled = false });
            builder.HasData(new Country { Id = 206, Text = "Somalia", Alpha2Code = "SO", Alpha3Code = "SOM", Value = "706", SortOrder = 706, IsDisabled = false });
            builder.HasData(new Country { Id = 207, Text = "South Africa", Alpha2Code = "ZA", Alpha3Code = "ZAF", Value = "710", SortOrder = 710, IsDisabled = false });
            builder.HasData(new Country { Id = 208, Text = "South Georgia and the South Sandwich Islands", Alpha2Code = "GS", Alpha3Code = "SGS", Value = "239", SortOrder = 239, IsDisabled = false });
            builder.HasData(new Country { Id = 209, Text = "South Sudan", Alpha2Code = "SS", Alpha3Code = "SSD", Value = "728", SortOrder = 728, IsDisabled = false });
            builder.HasData(new Country { Id = 210, Text = "Spain", Alpha2Code = "ES", Alpha3Code = "ESP", Value = "724", SortOrder = 724, IsDisabled = false });
            builder.HasData(new Country { Id = 211, Text = "Sri Lanka", Alpha2Code = "LK", Alpha3Code = "LKA", Value = "144", SortOrder = 144, IsDisabled = false });
            builder.HasData(new Country { Id = 212, Text = "Sudan", Alpha2Code = "SD", Alpha3Code = "SDN", Value = "729", SortOrder = 729, IsDisabled = false });
            builder.HasData(new Country { Id = 213, Text = "Suriname", Alpha2Code = "SR", Alpha3Code = "SUR", Value = "740", SortOrder = 740, IsDisabled = false });
            builder.HasData(new Country { Id = 214, Text = "Svalbard and Jan Mayen", Alpha2Code = "SJ", Alpha3Code = "SJM", Value = "744", SortOrder = 744, IsDisabled = false });
            builder.HasData(new Country { Id = 215, Text = "Sweden", Alpha2Code = "SE", Alpha3Code = "SWE", Value = "752", SortOrder = 752, IsDisabled = false });
            builder.HasData(new Country { Id = 216, Text = "Switzerland", Alpha2Code = "CH", Alpha3Code = "CHE", Value = "756", SortOrder = 756, IsDisabled = false });
            builder.HasData(new Country { Id = 217, Text = "Syrian Arab Republic", Alpha2Code = "SY", Alpha3Code = "SYR", Value = "760", SortOrder = 760, IsDisabled = false });
            builder.HasData(new Country { Id = 218, Text = "Taiwan (Province of China)", Alpha2Code = "TW", Alpha3Code = "TWN", Value = "158", SortOrder = 158, IsDisabled = false });
            builder.HasData(new Country { Id = 219, Text = "Tajikistan", Alpha2Code = "TJ", Alpha3Code = "TJK", Value = "762", SortOrder = 762, IsDisabled = false });
            builder.HasData(new Country { Id = 220, Text = "Tanzania, the United Republic of", Alpha2Code = "TZ", Alpha3Code = "TZA", Value = "834", SortOrder = 834, IsDisabled = false });
            builder.HasData(new Country { Id = 221, Text = "Thailand", Alpha2Code = "TH", Alpha3Code = "THA", Value = "764", SortOrder = 764, IsDisabled = false });
            builder.HasData(new Country { Id = 222, Text = "Timor-Leste", Alpha2Code = "TL", Alpha3Code = "TLS", Value = "626", SortOrder = 626, IsDisabled = false });
            builder.HasData(new Country { Id = 223, Text = "Togo", Alpha2Code = "TG", Alpha3Code = "TGO", Value = "768", SortOrder = 768, IsDisabled = false });
            builder.HasData(new Country { Id = 224, Text = "Tokelau", Alpha2Code = "TK", Alpha3Code = "TKL", Value = "772", SortOrder = 772, IsDisabled = false });
            builder.HasData(new Country { Id = 225, Text = "Tonga", Alpha2Code = "TO", Alpha3Code = "TON", Value = "776", SortOrder = 776, IsDisabled = false });
            builder.HasData(new Country { Id = 226, Text = "Trinidad and Tobago", Alpha2Code = "TT", Alpha3Code = "TTO", Value = "780", SortOrder = 780, IsDisabled = false });
            builder.HasData(new Country { Id = 227, Text = "Tunisia", Alpha2Code = "TN", Alpha3Code = "TUN", Value = "788", SortOrder = 788, IsDisabled = false });
            builder.HasData(new Country { Id = 228, Text = "Turkey", Alpha2Code = "TR", Alpha3Code = "TUR", Value = "792", SortOrder = 792, IsDisabled = false });
            builder.HasData(new Country { Id = 229, Text = "Turkmenistan", Alpha2Code = "TM", Alpha3Code = "TKM", Value = "795", SortOrder = 795, IsDisabled = false });
            builder.HasData(new Country { Id = 230, Text = "Turks and Caicos Islands", Alpha2Code = "TC", Alpha3Code = "TCA", Value = "796", SortOrder = 796, IsDisabled = false });
            builder.HasData(new Country { Id = 231, Text = "Tuvalu", Alpha2Code = "TV", Alpha3Code = "TUV", Value = "798", SortOrder = 798, IsDisabled = false });
            builder.HasData(new Country { Id = 232, Text = "Uganda", Alpha2Code = "UG", Alpha3Code = "UGA", Value = "800", SortOrder = 800, IsDisabled = false });
            builder.HasData(new Country { Id = 233, Text = "Ukraine", Alpha2Code = "UA", Alpha3Code = "UKR", Value = "804", SortOrder = 804, IsDisabled = false });
            builder.HasData(new Country { Id = 234, Text = "United Arab Emirates", Alpha2Code = "AE", Alpha3Code = "ARE", Value = "784", SortOrder = 784, IsDisabled = false });
            builder.HasData(new Country { Id = 235, Text = "United Kingdom of Great Britain and Northern Ireland", Alpha2Code = "GB", Alpha3Code = "GBR", Value = "826", SortOrder = 826, IsDisabled = false });
            builder.HasData(new Country { Id = 236, Text = "United States Minor Outlying Islands", Alpha2Code = "UM", Alpha3Code = "UMI", Value = "581", SortOrder = 581, IsDisabled = false });
            builder.HasData(new Country { Id = 237, Text = "United States of America", Alpha2Code = "US", Alpha3Code = "USA", Value = "840", SortOrder = 1, IsDisabled = false });
            builder.HasData(new Country { Id = 238, Text = "Uruguay", Alpha2Code = "UY", Alpha3Code = "URY", Value = "858", SortOrder = 858, IsDisabled = false });
            builder.HasData(new Country { Id = 239, Text = "Uzbekistan", Alpha2Code = "UZ", Alpha3Code = "UZB", Value = "860", SortOrder = 860, IsDisabled = false });
            builder.HasData(new Country { Id = 240, Text = "Vanuatu", Alpha2Code = "VU", Alpha3Code = "VUT", Value = "548", SortOrder = 548, IsDisabled = false });
            builder.HasData(new Country { Id = 241, Text = "Venezuela (Bolivarian Republic of)", Alpha2Code = "VE", Alpha3Code = "VEN", Value = "862", SortOrder = 862, IsDisabled = false });
            builder.HasData(new Country { Id = 242, Text = "Viet Nam", Alpha2Code = "VN", Alpha3Code = "VNM", Value = "704", SortOrder = 704, IsDisabled = false });
            builder.HasData(new Country { Id = 243, Text = "Virgin Islands (British)", Alpha2Code = "VG", Alpha3Code = "VGB", Value = "92", SortOrder = 92, IsDisabled = false });
            builder.HasData(new Country { Id = 244, Text = "Virgin Islands (U.S.)", Alpha2Code = "VI", Alpha3Code = "VIR", Value = "850", SortOrder = 850, IsDisabled = false });
            builder.HasData(new Country { Id = 245, Text = "Wallis and Futuna", Alpha2Code = "WF", Alpha3Code = "WLF", Value = "876", SortOrder = 876, IsDisabled = false });
            builder.HasData(new Country { Id = 246, Text = "Western Sahara", Alpha2Code = "EH", Alpha3Code = "ESH", Value = "732", SortOrder = 732, IsDisabled = false });
            builder.HasData(new Country { Id = 247, Text = "Yemen", Alpha2Code = "YE", Alpha3Code = "YEM", Value = "887", SortOrder = 887, IsDisabled = false });
            builder.HasData(new Country { Id = 248, Text = "Zambia", Alpha2Code = "ZM", Alpha3Code = "ZMB", Value = "894", SortOrder = 894, IsDisabled = false });
            builder.HasData(new Country { Id = 249, Text = "Zimbabwe", Alpha2Code = "ZW", Alpha3Code = "ZWE", Value = "716", SortOrder = 716, IsDisabled = false });
        }

        public void SeedDebug(EntityTypeBuilder<Country> builder)
        {
#if DEBUG

#endif
        }
    }
}