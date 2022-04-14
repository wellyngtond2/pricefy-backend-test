﻿using System;

namespace PricefyChallenge.Core.Entities
{
    public class Movie : EntityBase
    {
        public MovieAttachment MovieAttachment { get; set; }
        public int MovieAttachmentId { get; set; }
        public string TConst { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
        public int RunTimeMinutes { get; set; }
        public string Genres { get; set; }

    }
}