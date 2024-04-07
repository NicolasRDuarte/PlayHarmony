namespace PlayHarmony.Models;

public class DetailsVM
{
    public Artista Anterior { get; set; }
    public Artista Atual { get; set; }
    public Artista Proximo { get; set; }
    public List<Tipo> Tipos { get; set; }
}