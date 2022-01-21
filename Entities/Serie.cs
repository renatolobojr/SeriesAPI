namespace SeriesAPI.Entities
{
    public record Serie : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }

        public Serie(int id, string titulo, string descricao, int ano)
        {
            Id = id;                //base
            Titulo = titulo;        //this
            Descricao = descricao;  //this
            Ano = ano;              //this
        }


        public Serie MakeSerie(int id)
        {
            return new Serie(id, " teste", "teste", 120);
        }

        internal void Update(Serie serie)
        {
            Titulo =    serie.Titulo is null?       Titulo:     serie.Titulo;        
            Descricao = serie.Descricao is null ?   Descricao : serie.Descricao;  
            Ano =       serie.Ano == 0 ?              Ano :       serie.Ano;             
        }
    }
}
