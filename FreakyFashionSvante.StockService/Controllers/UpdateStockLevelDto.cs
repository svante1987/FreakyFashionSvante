﻿namespace FreakyFashionSvante.StockService.Controllers
{
    public class UpdateStockLevelDto
    {
        public string ArticleNumber { get; set; }

        public int StockLevel { get; set; }
    }
}