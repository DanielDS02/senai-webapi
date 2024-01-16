namespace ComoVcEsta.Controllers;

public class Sentimento
{
    public string ArquivoSentimento { get; set; }
    public Sentimento()
    {
        Nome = string.Empty;
        HoraDoRegistro = DateTime.Now.ToString("hh_mm_ss");
        ComoVcEsta = string.Empty;
        string formatoDataArquivo = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss");
        ArquivoSentimento = $"{AppDomain.CurrentDomain.BaseDirectory}\\como_esta_vc_{formatoDataArquivo}.txt";
    }
    public void EscrevaOSentimento(string nome, string comoVcEsta)
    {
        if (System.IO.File.Exists(ArquivoSentimento) is false)
        {
            using (System.IO.File.Create(ArquivoSentimento)) { };
        }
        Sentimento sentimento = new Sentimento()
        {
            Nome = nome,
            ComoVcEsta = comoVcEsta
        };

        File.AppendAllText(ArquivoSentimento, sentimento.ToString());
    }

    public string Nome { get; set; }
    public string HoraDoRegistro { get; set; }
    public string ComoVcEsta { get; set; }

    const string delimitador = ";";


    public override string ToString()
    {
        return $"{Nome}{delimitador}{ComoVcEsta}{delimitador}{HoraDoRegistro}\r\n";
    }

    public Sentimento ConverterString(string texto)
    {
        string[] sentimentoEmPartes = texto.Split(delimitador);

        Nome = sentimentoEmPartes[0];
        ComoVcEsta = sentimentoEmPartes[1];
        HoraDoRegistro = sentimentoEmPartes[2];

        return this;
    }

    public Sentimento[] TrazerSentimentos()
    {
        var sentimentos = new List<Sentimento> { };
        var valorBase = "como_esta_vc_";

        var arquivos = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"{valorBase}*");
        foreach (var arquivo in arquivos)
        {
            var date = arquivo.Split(valorBase);
            var conteudoArquivo = File.ReadAllText(arquivo);
            Sentimento sentimento = new ();
            sentimento.ConverterString(conteudoArquivo);
            sentimentos.Add(sentimento);
        }
        return sentimentos.ToArray();
    }
}
