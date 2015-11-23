namespace NFe.Impressao
{
    public interface IDanfe
    {
        /// <summary>
        /// Abre a janela de visualiza��o do DANFE
        /// </summary>
        /// <param name="modal">Se true, exibe a visualiza��o em Modal. O modo modal est� dispon�vel apenas para WinForms</param>
        void Visualizar(bool modal = true);

        /// <summary>
        ///  Abre a janela de visualiza��o do design do DANFE.
        /// Chame esse m�todo se desja fazer altera��es no design do DANFE em modo run-time
        /// </summary>
        /// <param name="modal">Se true, exibe a visualiza��o em Modal. O modo modal est� dispon�vel apenas para WinForms</param>
        void ExibirDesign(bool modal = false);

        /// <summary>
        /// Envia a impress�o do DANFE diretamente para a impressora
        /// </summary>
        /// <param name="exibirDialogo">Se true exibe o di�logo Imprimindo...</param>
        /// <param name="impressora">Passe a string com o nome da impressora para imprimir diretamente em determinada impressora. Caso contr�rio, a impress�o ser� feita na impressora que estiver como padr�o</param>
        void Imprimir(bool exibirDialogo = true, string impressora = "");
    }
}