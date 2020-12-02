using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class DetailRepository : IDetailRepository
    {
        private readonly Detail[] details = new[]
        {
            new Detail(1,"058143843","Россия", "Фильтр воздушный", "FORD Focus (1.4/2.0) (04-) VOLVO C30, S40, V50 (1.6/2.0) (04-) OE 1232496", 200m),
            new Detail(2, "028127435B", "Россия","Фильтр топливный MANNFILTER WK 69/2", "Подходит для: Audi A3, Audi TTS, Audi TT, BMW 1 series, Seat Leon, Seat Ibiza, Seat Toledo, Seat Cordoba, Seat Altea, Skoda Rapid, Skoda Praktik, Skoda Octavia, Skoda Fabia, Skoda Roomster, Volkswagen Caddy, Volkswagen Jetta,Volkswagen Golf, Volkswagen Beetle, Volkswagen Eos, Volkswagen Touran, Volkswagen Polo", 1250m),
            new Detail(3, "8E0698451L","Россия" ,"Колодки тормозные передние", "brembo P85075 для Volkswagen, Skoda, Audi, SEAT (4 шт.)", 600m),
            new Detail(4,"N10140105","Китай", "Свеча накаливания", "AUDIFORDSEATVW. 1 шт.", 340m),
            new Detail(5, "717469481", "Россия","Тормозной диск, задний", "300X20 LH=RH BMW 4-Series 2013 [34216864900], левый/правый F36", 1040m),
            new Detail(6, "4642343415","Россия" ,"Тормозной диск, передний", "добавить описание",1040m),
            new Detail(7,"058133843","Россия", "Топливный фильтр FILTRON PP 839", "подходит для: Ford Galaxy, Seat Ibiza, Seat Toledo, Seat Cordoba, Seat Alhambra, Skoda Felicia, Volkswagen Jetta, Volkswagen Golf, Volkswagen Polo, Volkswagen Transporter, Volkswagen Passat, Volkswagen Sharan, Volkswagen Vento, Volkswagen Caravelle, SEAT Terra, Volkswagen LT35, Volkswagen LT28, Volkswagen LT40, Volkswagen LT31, Volkswagen LT50",759m),
            new Detail(8, "0281233TY5B", "Россия","Сайлентблок задней подвески LYNXauto C8326", "Мост установки: задний. Сторона установки: левый, правый. Наружный диаметр 44 мм. Внутренний диаметр 14.2 мм. Длина 59 мм. Модель автомобиля: Hyundai i30, Hyundai Equus, Hyundai Grandeur, Hyundai Elantra, Kia Optima, Kia Sorento, Kia Carnival, Kia Magentis, Kia Sportage, Kia Ceed, Kia Carens, KIA ProCeed",580m),
            new Detail(9, "8E0698P451L","Россия" ,"Свеча", "Добавить описание",789m),
            new Detail(10,"N1014QW0105","Китай", "Свеча накаливания", "добавить описание", 895m),
            new Detail(11, "7GH1769481", "Китай","Датчик давления масла", "AUDI 80 [B4] 1,6-2,8 09/91-1",250m),
            new Detail(12, "4642XC3415","Китай" ,"Фильтр масляный","добавить описание",340m),
        };

        public Detail[] GetAllByIds(IEnumerable<int> detailIds)
        {
            var foundDetails = from detail in details
                               join detailId in detailIds on detail.Id equals detailId
                               select detail;

            return foundDetails.ToArray();
        }

        public Detail[] GetAllByPart_number(string part_number)
        {
            return details.Where(detail => detail.Part_number == part_number).ToArray();
        }

        public Detail[] GetAllByTitleOrCompany(string query)
        {
            return details.Where(detail => detail.Title.Contains(query)||detail.Company.Contains(query)).ToArray();

        }

        public Detail GetById(int id)
        {
            return details.Single(detail => detail.Id == id);
        }
    }
}
