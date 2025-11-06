using System.Data;

namespace W3___REST_API {
    public record CerealItem {
        public string? name {  get; set; }
        public string? mfr { get; set; }
        public string? type { get; set; }
        public int calories { get; set; }
        public int protein { get; set; }
        public int fat {  get; set; }
        public int sodium { get; set; }
        public float fiber { get; set; }
        public float carbo { get; set; }
        public int sugars { get; set; }
        public int potass { get; set; }
        public int vitamins { get; set; }
        public int shelf { get; set; }
        public float weight { get; set; }
        public float cups { get; set; }
        public string? rating { get; set; } 

        /*public CerealItem(String[] dataRow) {
            this.name = (String) dataRow[0];
            this.mfr = (String) dataRow[1];
            this.type = (String) dataRow[2];
            this.calories = int.Parse(dataRow[3]);/*
            this.protein = (int) dataRow[4];
            this.fat = (int) dataRow[5];
            this.sodium = (int) dataRow[6];
            this.fiber = (int) dataRow[7];
            this.carbo = (int) dataRow[8];
            this.sugars = (int) dataRow[9];
            this.potass = (int) dataRow[10];
            this.vitamins = (int) dataRow[11];
            this.shelf = (int) dataRow[12];
            this.weight = (float) dataRow[13];
            this.cups = (float) dataRow[14];
            this.rating = (String) dataRow[15
        }*/
    }
}
