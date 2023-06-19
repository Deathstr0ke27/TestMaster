using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMaster2.Models;

[Table("tb_prova")]
public class Prova
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public DateTime Prazo { get; set; }
    public double Peso { get; set; }
    public string Nome { get; set; }
    [ForeignKey("MateriaId")]
    public Materia Materia { get; set; }

    public int? MateriaId {get; set; }
    public Prova(int? id, DateTime prazo, double peso, string nome, int? materiaId)
    {
        Id = id;
        Prazo = prazo;
        Peso = peso;
        Nome = nome;
        MateriaId = materiaId;
    }

    public override string ToString()
    {
        return $"Prova: Id={Id}, Prazo={Prazo}, Peso={Peso}, Nome={Nome}, MateriaId={MateriaId}";
    }
}