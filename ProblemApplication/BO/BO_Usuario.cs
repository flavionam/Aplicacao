using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using System.IO;
using Util;

namespace BO
{
    public class BO_Usuario
    {      
        private string localArquivoUsuarios = @"problem.txt";
        
        public  void preencherDataGrid(ref DataGridView dgUsuarios)
        {
            try
            {
                List<Usuario> listaUsuarios = new List<Usuario>();

                listaUsuarios = salvarUsuariosArquivo();

                dgUsuarios.DataSource = listaUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro não tratado " + ex.Message);
            }
        }

        private List<Usuario> salvarUsuariosArquivo()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            int tamanhoNome = 20;
            int tamanhoEmail = 20;
            int tamanhoData = 8;
            int tamanhoCelular = 15;
            int tamanhoTelResidencial = 15;


            try
            {
                Contexto db = new Contexto();

                using (StreamReader sr = new StreamReader(localArquivoUsuarios))
                {
                    String linha;

                    while ((linha = sr.ReadLine()) != null)
                    {
                        Usuario usuario = new Usuario();
                        int indiceInicial = 0;

                        usuario.Nome = linha.Substring(indiceInicial, tamanhoNome);
                        indiceInicial += tamanhoNome;
                        usuario.Email = Validacoes.validarEmail(linha.Substring(indiceInicial, tamanhoEmail));
                        indiceInicial += tamanhoEmail;
                        usuario.DataNascimento = Validacoes.validarData(linha.Substring(indiceInicial, tamanhoData));
                        indiceInicial += tamanhoData;
                        usuario.Celular = linha.Substring(indiceInicial, tamanhoCelular);
                        indiceInicial += tamanhoCelular;
                        usuario.TelefoneResidencial = linha.Substring(indiceInicial, tamanhoTelResidencial);

                        db.Usuario.Add(usuario);
                        listaUsuarios.Add(usuario);
                    }
                }

                db.SaveChanges();

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Arquivo não encontrado.", "ERRO");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Diretório não encontrado.", "ERRO");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Conteúdo do arquivo fora do padrão.", "ERRO");

                //limpo a lista para certificar que o usuário verá os usuários apenas qndo
                //estes estiverem gravados no banco
                listaUsuarios.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //aqui provavelmente poderíamos ter um log de sucesso ou erro na aplicação
            }

            return listaUsuarios;
            
        }

    }
}
