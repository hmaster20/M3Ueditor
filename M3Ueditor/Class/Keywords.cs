using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M3Ueditor
{
    /// <summary>Класс, обеспечивающий параметризацию</summary>
    public class Keywords
    {
        string[] keys = {
            "url-tvg",
            "cache" ,
            "deinterlace ",
            "aspect-ratio",
            "croppadd",
            "num"
        };

        /// <summary>Выдает фиксированный реестр тэгов с описанием</summary>
        public static Dictionary<string, string> getTags()
        {
            Dictionary<string, string> chTags = new Dictionary<string, string>();
            chTags.Add("url-tvg", "адрес архива с телепрограммой(можно несколько адресов через запятую)");
            chTags.Add("cache", "значение кэша");
            chTags.Add("reportstat", "адрес скрипта для сбора статистики просмотра");
            chTags.Add("reportlog", "адрес скрипта для сбора логов");
            chTags.Add("url-m3u", "новый адрес списка каналов (для массового изменения адреса в плеерах у абонентов)");
            chTags.Add("tvg-logo", "шаблон ссылки для установки логотипов сразу всех каналов(поддерживаются переменные %name% - url-кодированное название канала в нижнем регистре, %tvg% - значение tvg-name/tvg-id канала, %num% - номер канала, например, http://ваш-сервер/логотипы/%name%.png)");
            chTags.Add("url-scrlogo", "адрес изображения png/jpg/gif/bmp для логотипа в центре экрана, рекомендуемый размер 200-300px под чёрный фон");
            chTags.Add("nameaskey", "(0/1) использовать название канала в качестве ключевого поля для сохранения настроек, а не его адрес(использовать в динамически генерируемых списках)");
            chTags.Add("numwzero", "(0/1) добавлять нули перед короткими номерами каналов, например, 001, 002, ...");
            chTags.Add("tvg-name", "имя канала в файле телепрограммы (можно не указывать если совпадает с названием канала)");
            chTags.Add("tvg-id", "идентификатор канала в файле телепрограммы (можно не указывать если совпадает с названием канала; имеет приоритет над tvg-name)");
            chTags.Add("tvg-shift", "коррекция по времени, в часах(...-2, -1, 0, +1, +2, ...)");
            //chTags.Add("tvg-logo", "адрес изображения png/jpg/gif/bmp или имя логотипа канала из встроенной базы или имя файла(без расширения!) из папки Icons *.png/jpg/gif/bmp(можно не указывать если совпадает с названием канала)");
            chTags.Add("group-title", "заголовок группы каналов");
            chTags.Add("deinterlace", "деинтерлейс (0-выкл,1-Blend,2-Mean, ...)");
            chTags.Add("aspect-ratio", "соотношение сторон(None, 4:3, 16:9, ...)");
            chTags.Add("croppadd", "обрезка кадра горизонтальxвертикаль в пикселах, например 15x10");
            chTags.Add("num", "номер канала(1-9999) в сетке вещания провайдера вместо обычного порядкового");
            return chTags;
        }
    }
}