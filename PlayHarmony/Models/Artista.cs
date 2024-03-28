namespace PlayHarmony.Models;
public class Artista
{
      public int Id { get; set; }
      public string Nome { get; set; }
      public int Nalbuns { get; set; }
      public List<string> Tipo { get; set; } = [];
      public string Imagem { get; set; }
      public string Descricao { get; set; }
}
