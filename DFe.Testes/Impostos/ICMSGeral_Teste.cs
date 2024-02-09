﻿using System;
using System.ComponentModel;
using DFe.Testes.Impostos.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using NFe.Classes.Informacoes.Emitente;
using NFe.Utils.Tributacao.Estadual;

namespace DFe.Testes.Impostos
{
    [TestClass]
    public class ICMSGeral_Teste
    {
        #region CRT - Normal

        [TestMethod]
        [DataTestMethod]
        [DataRow(CRT.RegimeNormal, OrigemMercadoria.OmEstrangeiraAdquiridaBrasil, DeterminacaoBaseIcms.DbiMargemValorAgregado, 1000, 18, 180, null, null)]
        [DataRow(CRT.RegimeNormal, OrigemMercadoria.OmEstrangeiraAdquiridaBrasilSemSimilar, DeterminacaoBaseIcms.DbiMargemValorAgregado, 1000, 18, 180, 0, 0)]
        [DataRow(CRT.RegimeNormal, OrigemMercadoria.OmEstrangeiraImportacaoDireta, DeterminacaoBaseIcms.DbiValorOperacao, 1000, 18, 180, 0, 0)]
        [DataRow(CRT.RegimeNormal, OrigemMercadoria.OmEstrangeiraImportacaoDiretaSemSimilar, DeterminacaoBaseIcms.DbiMargemValorAgregado, 1000, 18, 180, null, null)]
        [DataRow(CRT.RegimeNormal, OrigemMercadoria.OmNacional, DeterminacaoBaseIcms.DbiPrecoTabelado, 1000, 18, 180, null, null)]
        [DataRow(CRT.RegimeNormal, OrigemMercadoria.OmNacionalConteudoImportacaoInferiorIgual40, DeterminacaoBaseIcms.DbiPauta, 1000, 18, 180, 0, 0)]
        public void ObterICMSBasico_ICMS00_Teste(CRT crt, OrigemMercadoria origem, DeterminacaoBaseIcms modBC, object vBC, object pICMS, object vICMS, object pFCP, object vFCP)
        {
            /** 1) Preparação **/
            var icmsGeral = new ICMSGeral()
            {
                orig = origem,
                CST = Csticms.Cst00,
                modBC = modBC,
                vBC = Convert.ToDecimal(vBC),
                pICMS = Convert.ToDecimal(pICMS),
                vICMS = Convert.ToDecimal(vICMS),
                pFCP = Convert.ToDecimal(pFCP),
                vFCP = Convert.ToDecimal(vFCP)
            };

            /** 2) Execução **/
            var tagGerada = icmsGeral.ObterICMSBasico(crt);

            /** 2) Veerificação **/
            /** 2.1) Garante que o tipo da classe gerada foi correta**/
            Assert.IsInstanceOfType(tagGerada, typeof(ICMS00));

            /** 2.2) Garante que o conteúdo repassado para as propriedades estejam corretos **/
            var tagICMSGerada = (tagGerada as ICMS00);
            Assert.AreEqual(origem, tagICMSGerada.orig);
            Assert.AreEqual(Csticms.Cst00, tagICMSGerada.CST);
            Assert.AreEqual(modBC, tagICMSGerada.modBC);
            Assert.AreEqual(Convert.ToDecimal(vBC), tagICMSGerada.vBC);
            Assert.AreEqual(Convert.ToDecimal(pICMS), tagICMSGerada.pICMS);
            Assert.AreEqual(Convert.ToDecimal(vICMS), tagICMSGerada.vICMS);
            Assert.AreEqual(Convert.ToDecimal(pFCP), tagICMSGerada.pFCP);
            Assert.AreEqual(Convert.ToDecimal(vFCP), tagICMSGerada.vFCP);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(CRT.RegimeNormal, OrigemMercadoria.OmEstrangeiraAdquiridaBrasil, DeterminacaoBaseIcms.DbiMargemValorAgregado, 1000, 18, 180, 0, 0, 0, DeterminacaoBaseIcmsSt.DbisListaNegativa, 15, 2, 1000, 18, 25, 0, 0, 0)]
        [DataRow(CRT.RegimeNormal, OrigemMercadoria.OmEstrangeiraAdquiridaBrasilSemSimilar, DeterminacaoBaseIcms.DbiMargemValorAgregado, 1000, 18, 180, 0, 0, 0, DeterminacaoBaseIcmsSt.DbisListaNegativa, 15, 2, 1000, 18, 25, 100, 10, 10)]
        [DataRow(CRT.RegimeNormal, OrigemMercadoria.OmNacionalConteudoImportacaoInferiorIgual40, DeterminacaoBaseIcms.DbiMargemValorAgregado, 100, 18, 18, 0, 0, 0, DeterminacaoBaseIcmsSt.DbisListaNegativa, 15, 2, 1000, 18, 25, 0, 0, 0)]
        public void ObterICMSBasico_ICMS10_Teste(CRT crt, OrigemMercadoria origem, DeterminacaoBaseIcms modBC, object vBC, object pICMS, object vICMS, object vBCFCP, object pFCP, object vFCP, DeterminacaoBaseIcmsSt modBCST, object pMVAST, object pRedBCST, object vBCST, object pICMSST, object vICMSST, object vBCFCPST, object pFCPST, object vFCPST)
        {
            /** 1) Preparação **/
            var icmsGeral = new ICMSGeral()
            {
                orig = origem,
                CST = Csticms.Cst10,
                modBC = modBC,
                vBC = Convert.ToDecimal(vBC),
                pICMS = Convert.ToDecimal(pICMS),
                vICMS = Convert.ToDecimal(vICMS),
                pFCP = Convert.ToDecimal(pFCP),
                vFCP = Convert.ToDecimal(vFCP),
                vBCFCP = Convert.ToDecimal(vBCFCP),
                modBCST = modBCST,
                pMVAST = Convert.ToDecimal(pMVAST),
                pRedBCST = Convert.ToDecimal(pRedBCST),
                vBCST = Convert.ToDecimal(vBCST),
                pICMSST = Convert.ToDecimal(pICMSST),
                vICMSST = Convert.ToDecimal(vICMSST),
                vBCFCPST = Convert.ToDecimal(vBCFCPST),
                pFCPST = Convert.ToDecimal(pFCPST),
                vFCPST = Convert.ToDecimal(vFCPST)
            };

            /** 2) Execução **/
            var tagGerada = icmsGeral.ObterICMSBasico(crt);

            /** 2) Veerificação **/
            /** 2.1) Garante que o tipo da classe gerada foi correta**/
            Assert.IsInstanceOfType(tagGerada, typeof(ICMS10));

            /** 2.2) Garante que o conteúdo repassado para as propriedades estejam corretos **/
            var tagICMSGerada = (tagGerada as ICMS10);
            Assert.AreEqual(origem, tagICMSGerada.orig);
            Assert.AreEqual(Csticms.Cst10, tagICMSGerada.CST);
            Assert.AreEqual(modBC, tagICMSGerada.modBC);
            Assert.AreEqual(Convert.ToDecimal(vBC), tagICMSGerada.vBC);
            Assert.AreEqual(Convert.ToDecimal(pICMS), tagICMSGerada.pICMS);
            Assert.AreEqual(Convert.ToDecimal(vICMS), tagICMSGerada.vICMS);
            Assert.AreEqual(Convert.ToDecimal(pFCP), tagICMSGerada.pFCP);
            Assert.AreEqual(Convert.ToDecimal(vFCP), tagICMSGerada.vFCP);
            Assert.AreEqual(Convert.ToDecimal(vBCFCP), tagICMSGerada.vBCFCP);
            Assert.AreEqual(modBCST, tagICMSGerada.modBCST);
            Assert.AreEqual(Convert.ToDecimal(pMVAST), tagICMSGerada.pMVAST);
            Assert.AreEqual(Convert.ToDecimal(pRedBCST), tagICMSGerada.pRedBCST);
            Assert.AreEqual(Convert.ToDecimal(vBCST), tagICMSGerada.vBCST);
            Assert.AreEqual(Convert.ToDecimal(pICMSST), tagICMSGerada.pICMSST);
            Assert.AreEqual(Convert.ToDecimal(vICMSST), tagICMSGerada.vICMSST);
            Assert.AreEqual(Convert.ToDecimal(vBCFCPST), tagICMSGerada.vBCFCPST);
            Assert.AreEqual(Convert.ToDecimal(pFCPST), tagICMSGerada.pFCPST);
            Assert.AreEqual(Convert.ToDecimal(vFCPST), tagICMSGerada.vFCPST);
        }

        //TODO: Falta criar os métodos de testes dos demais CSTs do ICMS (CTR = Normal)

        #endregion

        #region CRT - Simples

        [TestMethod]
        [DataTestMethod]
        [DataRow(CRT.SimplesNacional, OrigemMercadoria.OmEstrangeiraAdquiridaBrasil, 100, 18)]
        public void ObterICMSBasico_CSOSN101_Teste(CRT crt, OrigemMercadoria origem, object pCredSN, object vCredICMSSN)
        {
            /** 1) Preparação **/
            var icmsGeral = new ICMSGeral()
            {
                orig = origem,
                CSOSN = Csosnicms.Csosn101,
                pCredSN = Convert.ToDecimal(pCredSN),
                vCredICMSSN = Convert.ToDecimal(vCredICMSSN)
            };

            /** 2) Execução **/
            var tagGerada = icmsGeral.ObterICMSBasico(crt);

            /** 2) Veerificação **/
            /** 2.1) Garante que o tipo da classe gerada foi correta**/
            Assert.IsInstanceOfType(tagGerada, typeof(ICMSSN101));

            /** 2.2) Garante que o conteúdo repassado para as propriedades estejam corretos **/
            var tagICMSGerada = (tagGerada as ICMSSN101);
            Assert.AreEqual(origem, tagICMSGerada.orig);
            Assert.AreEqual(Csosnicms.Csosn101, tagICMSGerada.CSOSN);
            Assert.AreEqual(Convert.ToDecimal(pCredSN), tagICMSGerada.pCredSN);
            Assert.AreEqual(Convert.ToDecimal(vCredICMSSN), tagICMSGerada.vCredICMSSN);
        }

        //TODO: Falta criar os métodos de testes dos demais CSOSNs do ICMS (CTR = Simples)

        #endregion

        #region CST 61 - Tributação Monofásica Sobre os Combustíveis

        [TestMethod]
        [DynamicData(nameof(ICMSGeralTestData.ObterRegimesTributariosComOrigemECamposParaCst61), typeof(ICMSGeralTestData), DynamicDataSourceType.Method)]
        [DisplayName("Dado CST 61 quando obter ICMS então ICMS deve conter campos de tributação monofásica sobre combustíveis preenchidos")]
        public void DadoCST61QuandoObterICMSEntaoICMSDeveConterCamposDeTributacaoMonofasicaSobreCombustiveisPreenchidos(CRT crt, OrigemMercadoria origem, object vICMSMonoRet, object adRemICMSRet, object qBCMonoRet)
        {
            /** 1) Preparação **/
            var icmsGeral = new ICMSGeral()
            {
                orig = origem,
                CST = Csticms.Cst61,
                vICMSMonoRet = Convert.ToDecimal(vICMSMonoRet),
                adRemICMSRet = Convert.ToDecimal(adRemICMSRet),
                qBCMonoRet = Convert.ToDecimal(qBCMonoRet)
            };

            /** 2) Execução **/
            var tagGerada = icmsGeral.ObterICMSBasico(crt);

            /** 2) Veerificação **/
            /** 2.1) Garante que o tipo da classe gerada foi correta**/
            Assert.IsInstanceOfType(tagGerada, typeof(ICMS61));

            /** 2.2) Garante que o conteúdo repassado para as propriedades estejam corretos **/
            var tagICMSGerada = (tagGerada as ICMS61);
            Assert.AreEqual(origem, tagICMSGerada.orig);
            Assert.AreEqual(Csticms.Cst61, tagICMSGerada.CST);
            Assert.AreEqual(Convert.ToDecimal(vICMSMonoRet), tagICMSGerada.vICMSMonoRet);
            Assert.AreEqual(Convert.ToDecimal(adRemICMSRet), tagICMSGerada.adRemICMSRet);
            Assert.AreEqual(Convert.ToDecimal(qBCMonoRet), tagICMSGerada.qBCMonoRet);
        }

        [TestMethod]
        [DynamicData(nameof(ICMSGeralTestData.ObterRegimesTributariosComOrigemECamposParaCst61), typeof(ICMSGeralTestData), DynamicDataSourceType.Method)]
        [DisplayName("Não deve preencher campos que não sejam da tributação monofásica sobre combustíves quando dado CST 61")]
        public void NaoDevePreencherCamposQueNaoSejamDaTributacaoMonofasicaSobreCombustiveisQuandoDadoCst61(CRT crt, OrigemMercadoria origem, object vICMSMonoRet, object adRemICMSRet, object qBCMonoRet)
        {
            /** 1) Preparação **/
            var icmsGeral = new ICMSGeral()
            {
                orig = origem,
                CST = Csticms.Cst61,
                vICMSMonoRet = Convert.ToDecimal(vICMSMonoRet),
                adRemICMSRet = Convert.ToDecimal(adRemICMSRet),
                qBCMonoRet = Convert.ToDecimal(qBCMonoRet)
            };

            /** 2) Execução **/
            icmsGeral.ObterICMSBasico(crt);

            /** 2) Verificação **/
            VerificarSeNaoFoiPreenchidaOutroCampoQueNaoSejaCamposDaCst61(icmsGeral);
        }

        private void VerificarSeNaoFoiPreenchidaOutroCampoQueNaoSejaCamposDaCst61(ICMSGeral icmsGeral)
        {
            Assert.AreEqual(icmsGeral.pCredSN, 0);
            Assert.AreEqual(icmsGeral.vCredICMSSN, 0);
            Assert.AreEqual(icmsGeral.vBC, 0);
            Assert.AreEqual(icmsGeral.pICMS, 0);
            Assert.AreEqual(icmsGeral.vICMS, 0);
            Assert.AreEqual(icmsGeral.pFCP, null);
            Assert.AreEqual(icmsGeral.vFCP, null);
            Assert.AreEqual(icmsGeral.vBCFCP, null);
        }

        [TestMethod]
        [DynamicData(nameof(ICMSGeralTestData.ObterRegimesTributarios), typeof(ICMSGeralTestData), DynamicDataSourceType.Method)]
        [DisplayName("Dado CST 61 quando gerar ICMS então ICMS deve ser do tipo ICMS 61 e nenhum outro")]
        public void DadoCST61QuandoGerarICMSEntaoICMSDeveSerDoTipoICMS61ENenhumOutro(CRT crt)
        {
            /** 1) Preparação **/
            var icmsGeral = new ICMSGeral()
            {
                CST = Csticms.Cst61
            };

            /** 2) Execução **/
            var tagGerada = icmsGeral.ObterICMSBasico(crt);

            /** 2) Verificação **/
            VerificarSeNaoFoiGeradaOutroTipoDeIcmsQueNaoSejaOIcms61(tagGerada);
        }

        private void VerificarSeNaoFoiGeradaOutroTipoDeIcmsQueNaoSejaOIcms61(ICMSBasico tagGerada)
        {
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS00));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS02));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS10));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS15));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS20));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS30));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS40));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS51));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS53));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS51));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS60));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS70));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMS90));

            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMSSN101));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMSSN102));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMSSN201));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMSSN202));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMSSN500));
            Assert.IsNotInstanceOfType(tagGerada, typeof(ICMSSN900));
        }
        #endregion
    }
}
