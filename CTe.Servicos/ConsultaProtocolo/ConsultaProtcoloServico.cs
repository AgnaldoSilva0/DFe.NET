﻿/********************************************************************************/
/* Projeto: Biblioteca ZeusNFe                                                  */
/* Biblioteca C# para emissão de Nota Fiscal Eletrônica - NFe e Nota Fiscal de  */
/* Consumidor Eletrônica - NFC-e (http://www.nfe.fazenda.gov.br)                */
/*                                                                              */
/* Direitos Autorais Reservados (c) 2014 Adenilton Batista da Silva             */
/*                                       Zeusdev Tecnologia LTDA ME             */
/*                                                                              */
/*  Você pode obter a última versão desse arquivo no GitHub                     */
/* localizado em https://github.com/adeniltonbs/Zeus.Net.NFe.NFCe               */
/*                                                                              */
/*                                                                              */
/*  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la */
/* sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  */
/* Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) */
/* qualquer versão posterior.                                                   */
/*                                                                              */
/*  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   */
/* NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      */
/* ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor*/
/* do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              */
/*                                                                              */
/*  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto*/
/* com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  */
/* no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          */
/* Você também pode obter uma copia da licença em:                              */
/* http://www.opensource.org/licenses/lgpl-license.php                          */
/*                                                                              */
/* Zeusdev Tecnologia LTDA ME - adenilton@zeusautomacao.com.br                  */
/* http://www.zeusautomacao.com.br/                                             */
/* Rua Comendador Francisco josé da Cunha, 111 - Itabaiana - SE - 49500-000     */
/********************************************************************************/

using System.Threading.Tasks;
using CTe.Classes;
using CTe.Classes.Servicos.Consulta;
using CTe.Servicos.Factory;
using CTe.Utils.Extensoes;

namespace CTe.Servicos.ConsultaProtocolo
{
    public class ConsultaProtcoloServico
    {
        public retConsSitCTe ConsultaProtocolo(string chave, ConfiguracaoServico configuracaoServico = null)
        {
            var configServico = configuracaoServico ?? ConfiguracaoServico.Instancia;

            var consSitCTe = ClassesFactory.CriarconsSitCTe(chave, configServico);

            if (configServico.IsValidaSchemas)
                consSitCTe.ValidarSchema(configServico);

            consSitCTe.SalvarXmlEmDisco(configServico);

            var webService = WsdlFactory.CriaWsdlConsultaProtocolo(configServico);
            var retornoXml = webService.cteConsultaCT(consSitCTe.CriaRequestWs());

            var retorno = retConsSitCTe.LoadXml(retornoXml.OuterXml, consSitCTe);
            retorno.SalvarXmlEmDisco(chave, configServico);

            return retorno;
        }

        public retConsSitCTe ConsultaProtocoloV4(string chave, ConfiguracaoServico configuracaoServico = null)
        {
            var configServico = configuracaoServico ?? ConfiguracaoServico.Instancia;

            var consSitCTe = ClassesFactory.CriarconsSitCTe(chave, configServico);

            if (configServico.IsValidaSchemas)
                consSitCTe.ValidarSchema(configServico);

            consSitCTe.SalvarXmlEmDisco(configServico);

            var webService = WsdlFactory.CriaWsdlConsultaProtocoloV4(configServico);
            var retornoXml = webService.cteConsultaCT(consSitCTe.CriaRequestWs());

            var retorno = retConsSitCTe.LoadXml(retornoXml.OuterXml, consSitCTe);
            retorno.SalvarXmlEmDisco(chave, configServico);

            return retorno;
        }

        public async Task<retConsSitCTe> ConsultaProtocoloAsync(string chave, ConfiguracaoServico configuracaoServico = null)
        {
            var configServico = configuracaoServico ?? ConfiguracaoServico.Instancia;

            var consSitCTe = ClassesFactory.CriarconsSitCTe(chave, configServico);

            if (configServico.IsValidaSchemas)
                consSitCTe.ValidarSchema(configServico);

            consSitCTe.SalvarXmlEmDisco(configServico);

            var webService = WsdlFactory.CriaWsdlConsultaProtocolo(configServico);
            var retornoXml = await webService.cteConsultaCTAsync(consSitCTe.CriaRequestWs());

            var retorno = retConsSitCTe.LoadXml(retornoXml.OuterXml, consSitCTe);
            retorno.SalvarXmlEmDisco(chave, configServico);

            return retorno;
        }
    }
}