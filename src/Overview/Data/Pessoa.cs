namespace Overview.Data;

public class Pessoa
{
    public Pessoa(string nome)
    {
        Nome = nome;
    }
    public string Nome { get; set; }
    public Tarefa Tarefa { get; set; }
}

public class Tarefa
{
    public string Nome { get; set; }
    public List<Etapa> Etapas { get; set; }

    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
    
    public async Task ExecutarAsync()
    {
        foreach (var etapa in Etapas)
        {
            etapa.Status = EnumStatus.Executando;
            NotifyStateChanged();
            await Task.Delay(etapa.Tempo);
            etapa.Status = EnumStatus.Finalizado;
            NotifyStateChanged();
        }
    }
    
    public void Executar()
    {
        foreach (var etapa in Etapas)
        {
            etapa.Status = EnumStatus.Executando;
            NotifyStateChanged();
            Task.Delay(etapa.Tempo).Wait();
            etapa.Status = EnumStatus.Finalizado;
            NotifyStateChanged();
        }
    }
    
}

public class Etapa
{
    public Etapa(string nome, int tempo)
    {
        Nome = nome;
        Tempo = tempo;
        Status = EnumStatus.Pendente;
    }
    
    public string Nome { get; set; }
    public int Tempo { get; set; }
    public EnumStatus Status { get; set; }
}

public enum EnumStatus
{
    Pendente,
    Executando,
    Finalizado
}