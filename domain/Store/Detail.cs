using Store.Data;
using System;
using System.Text.RegularExpressions;

namespace Store
{
    public class Detail
    {
        private readonly DetailDTO dto;

        public int Id => dto.Id;

        public string Part_number
        {
            get => dto.Part_number;
            set
            {
                if (TryFormatPart_number(value, out string formattedPart_number))
                    dto.Part_number = formattedPart_number;

                throw new ArgumentException(nameof(Part_number));
            }
        }

        public string Company
        {
            get => dto.Company;
            set => dto.Company = value?.Trim();
        }

        public string Title 
        {
            get => dto.Title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Title));
            }
        }

        public string Description
        {
            get => dto.Description;
            set => dto.Description = value;
        }

        public decimal Price 
        {
            get => dto.Price;
            set => dto.Price = value;
        }

       internal Detail(DetailDTO dto)
        {
            this.dto = dto;
        }

        public static bool TryFormatPart_number(string part_number, out string formattedPart_number)
        {
            if (part_number == null)
            {
                formattedPart_number = null;
                return false;
            }

            formattedPart_number = part_number.Replace("-", "")
                                .Replace(" ", "");

            return Regex.IsMatch(formattedPart_number, "\\d{9}");
        }

        public static bool IsPart_number(string part_number)
            => TryFormatPart_number(part_number, out _);

        public static class DtoFactory
        {
            public static DetailDTO Create(string part_number, 
                                            string company,
                                            string  title,
                                            string description,
                                            decimal price)
            {
                if (TryFormatPart_number(part_number, out string formattedPart_number))
                    part_number = formattedPart_number;
                else
                    throw new ArgumentException(nameof(part_number));

                if (string.IsNullOrWhiteSpace(title))
                    throw new ArgumentException(nameof(title));

                return new DetailDTO
                {
                    Part_number = part_number,
                    Company = company?.Trim(),
                    Title = title.Trim(),
                    Description = description?.Trim(),
                    Price = price,
                };
            }
                                            
        }

        public static class Mapper
        {
            public static Detail Map(DetailDTO dto) => new Detail(dto);

            public static DetailDTO Map(Detail domain) => domain.dto;
        }

    }
}
