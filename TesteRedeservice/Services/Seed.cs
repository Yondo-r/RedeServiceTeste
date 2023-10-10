using TesteRedeservice.Models;
using TesteRedeservice.Services.Interfaces;

namespace TesteRedeservice.Services
{
    public class Seed : ISeed
    {

        public void SeedExercicios()
        {
            List<Exercicio> listaExercicios = MontarListaExercicios();
            //return listaExercicios
        }
        public List<Exercicio> MontarListaExercicios() 
        {
            List<Exercicio> exercicios = new List<Exercicio>();
            Exercicio ex1 = new Exercicio
            {
                Numero = 1,
                Descricao = "Faça a aplicação permitir a digitação de números e mostre esses números em tela de forma ordenada."
            };
            exercicios.Add(ex1);

            Exercicio ex2 = new Exercicio
            {
                Numero = 2,
                Descricao = "Agora grave os números visualizados cada 1 em uma linha em um arquivo texto na pasta raiz da aplicação de nome numeros_ordenar.txt."
            };
            exercicios.Add(ex2);

            Exercicio ex3 = new Exercicio
            {
                Numero = 3,
                Descricao = "Crie uma lista contendo 100 itens de uma classe de nome clsTeste com as propriedades codigo como número e descricao como texto, os objetos deverão ser criados com a propriedade codigo com números sequenciais(ex: 1, 2, 3, 4, 5) e a descricao como a data e hora atual(ex: 2022 / 10 / 13 08:50:22.123)"
            };
            exercicios.Add(ex3);

            Exercicio ex4 = new Exercicio
            {
                Numero = 4,
                Descricao = "Grave a lista do item 3, em um arquivo de nome data.json na pasta raiz da aplicação."
            };
            exercicios.Add(ex4);

            Exercicio ex5 = new Exercicio
            {
                Numero = 5,
                Descricao = "Crie um Grid, leia o arquivo data.json que foi gravado, e mostre os dados no Grid criado."
            };
            exercicios.Add(ex5);

            Exercicio ex6 = new Exercicio
            {
                Numero = 6,
                Descricao = "Consuma o webservice dos correios passando um CEP qualquer e mostre em tela o endereço que o mesmo retornar."
            };
            exercicios.Add(ex6);

            Exercicio ex7= new Exercicio
            {
                Numero = 7,
                Descricao = "Consuma a API para buscar a lista de bancos brasileiros; Mostre os dados de retorno da API em um Grid."
            };
            exercicios.Add(ex7);

            Exercicio ex8 = new Exercicio
            {
                Numero = 8,
                Descricao = "Pela aplicação faça o download da imagem https://redeservice.com.br/wp-content/uploads/2020/07/redeservice-logo.png, colocar na pasta do sistema, e criar alguma função para ler essa imagem e mostrar em tela no formato base64."
            };
            exercicios.Add(ex8);

            return exercicios;
        } 
            
    }
}
