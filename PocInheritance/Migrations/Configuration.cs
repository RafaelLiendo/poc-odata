namespace PocInheritance.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contexto context)
        {
            #region Usuarios
            context.Usuarios.AddOrUpdate(
              p => p.Id,
              new Usuario()
              {
                  Id = 1,
                  Nome = "Rafael Liendo"
              }
            );
            #endregion

            #region Uploads
            //fetch dummy photo
            WebClient wc = new WebClient();
            MemoryStream stream = new MemoryStream(wc.DownloadData("https://cdn.pixabay.com/photo/2015/12/22/04/00/photo-1103595_960_720.png"));
            BinaryReader reader = new BinaryReader(stream);
            byte[] photo = reader.ReadBytes((int)stream.Length);

            //create thumbnail
            var imageIn = Image.FromStream(stream).GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            byte[] thumbnail = ms.ToArray();


            context.Uploads.AddOrUpdate(
              p => p.Id,
              new Upload() {
                  Id = 1,
                  Blob = photo
              }
            );
            #endregion

            #region Artigos
            context.Artigos.AddOrUpdate(
              p => p.Titulo,
              new Artigo()
              {
                  Id = 1,
                  Titulo = "Layout titulo e texto",
                  ResponsavelId = 1,
                  Layout = true,
              },
              new Artigo()
              {
                  Id = 2,
                  Titulo = "Layout imagem, título e texto",
                  ResponsavelId = 1,
                  Layout = true,
                  Thumbnail = thumbnail
              },
              new Artigo()
              {
                  Id = 3,
                  Titulo = "Layout título, texto e vídeo",
                  ResponsavelId = 1,
                  Layout = true,
                  Thumbnail = thumbnail
              },
              new Artigo()
              {
                  Id = 4,
                  Titulo = "Layout título, texto e galeria",
                  ResponsavelId = 1,
                  Layout = true,
                  Thumbnail = thumbnail
              },
              new Artigo()
              {
                  Id = 5,
                  Titulo = "Layout imagem e título",
                  ResponsavelId = 1,
                  Layout = true,
                  Thumbnail = thumbnail
              },
              new Artigo()
              {
                  Id = 6,
                  Titulo = "Layout título e texto",
                  ResponsavelId = 1,
                  Layout = true,
                  Thumbnail = thumbnail
              },
              new Artigo()
              {
                  Id = 7,
                  Titulo = "Layout título e galeria",
                  ResponsavelId = 1,
                  Layout = true,
                  Thumbnail = thumbnail
              }
            );
            #endregion;

            #region Conteudos
            context.Conteudos.AddOrUpdate(
              p => p.Id,

            #region Layout titulo e texto
              new Titulo()
              {
                  Id = 1,
                  ArtigoId = 1,
                  Ordem = 1,
                  Importancia = 1,
                  Texto = "Layout título e texto"
              },
              new Paragrafo()
              {
                  Id = 2,
                  ArtigoId = 1,
                  Ordem = 2,
                  Texto = "Lorem ipsum dolor sit amet, pro ei rebum malorum platonem, sea te iisque dolorem definitionem. Sit ne noster intellegebat, nisl erat nominavi his eu. Populo nostro pertinacia ut nec. Solet affert iriure mei et, usu cu graeci everti concludaturque, id sit eros aeque. An delectus percipit facilisis vix. Tempor aliquam posidonium cu eum."
                          + "\nEx movet legere expetenda nam, soleat debitis blandit duo cu, vix no exerci alienum inciderint. Nostro praesent at nec. Harum nostrud reformidans an sea, et sit nostro mnesarchum quaerendum. Dicant appellantur eu duo. Te diam solum invenire pri, saepe nonumes ea eos."
              },
            #endregion

            #region Layout imagem, título e texto
              new Imagem()
              {
                  Id = 3,
                  ArtigoId = 2,
                  Ordem = 1,
                  Descricao = "Descrição da imagem",
                  UploadId = 1
              },
              new Titulo()
              {
                  Id = 4,
                  ArtigoId = 2,
                  Ordem = 2,
                  Importancia = 1,
                  Texto = "Layout imagem título e texto"
              },
              new Paragrafo()
              {
                  Id = 5,
                  ArtigoId = 2,
                  Ordem = 3,
                  Texto = "Lorem ipsum dolor sit amet, pro ei rebum malorum platonem, sea te iisque dolorem definitionem. Sit ne noster intellegebat, nisl erat nominavi his eu. Populo nostro pertinacia ut nec. Solet affert iriure mei et, usu cu graeci everti concludaturque, id sit eros aeque. An delectus percipit facilisis vix. Tempor aliquam posidonium cu eum."
                          + "\nEx movet legere expetenda nam, soleat debitis blandit duo cu, vix no exerci alienum inciderint. Nostro praesent at nec. Harum nostrud reformidans an sea, et sit nostro mnesarchum quaerendum. Dicant appellantur eu duo. Te diam solum invenire pri, saepe nonumes ea eos."
              },
            #endregion

            #region Layout título, texto e vídeo
              new Titulo()
              {
                  Id = 6,
                  ArtigoId = 3,
                  Ordem = 1,
                  Importancia = 1,
                  Texto = "Layout imagem titulo, texto e vídeo"
              },
              new Paragrafo()
              {
                  Id = 7,
                  ArtigoId = 3,
                  Ordem = 2,
                  Texto = "Lorem ipsum dolor sit amet, pro ei rebum malorum platonem, sea te iisque dolorem definitionem. Sit ne noster intellegebat, nisl erat nominavi his eu. Populo nostro pertinacia ut nec. Solet affert iriure mei et, usu cu graeci everti concludaturque, id sit eros aeque. An delectus percipit facilisis vix. Tempor aliquam posidonium cu eum."
                          + "\nEx movet legere expetenda nam, soleat debitis blandit duo cu, vix no exerci alienum inciderint. Nostro praesent at nec. Harum nostrud reformidans an sea, et sit nostro mnesarchum quaerendum. Dicant appellantur eu duo. Te diam solum invenire pri, saepe nonumes ea eos."
              },
              new Video()
              {
                  Id = 8,
                  ArtigoId = 3,
                  Ordem = 3,
                  YoutubeVideoId ="iT6vqeL-ysI"
              },
            #endregion

            #region Layout título, texto e galeria
              new Titulo()
              {
                  Id = 9,
                  ArtigoId = 4,
                  Ordem = 1,
                  Importancia = 1,
                  Texto = "Layout título, texto e galeria"
              },
              new Paragrafo()
              {
                  Id = 10,
                  ArtigoId = 4,
                  Ordem = 2,
                  Texto = "Lorem ipsum dolor sit amet, pro ei rebum malorum platonem, sea te iisque dolorem definitionem. Sit ne noster intellegebat, nisl erat nominavi his eu. Populo nostro pertinacia ut nec. Solet affert iriure mei et, usu cu graeci everti concludaturque, id sit eros aeque. An delectus percipit facilisis vix. Tempor aliquam posidonium cu eum."
                          + "\nEx movet legere expetenda nam, soleat debitis blandit duo cu, vix no exerci alienum inciderint. Nostro praesent at nec. Harum nostrud reformidans an sea, et sit nostro mnesarchum quaerendum. Dicant appellantur eu duo. Te diam solum invenire pri, saepe nonumes ea eos."
              },
              new Galeria()
              {
                  Id = 11,
                  ArtigoId = 4,
                  Ordem = 3         
              },
              new Imagem()
              {
                  Id = 12,
                  Ordem = 1,
                  GaleriaId = 11,
                  Descricao = "Imagem de galeria 1",
                  UploadId = 1                  
              },
              new Imagem()
              {
                  Id = 13,
                  Ordem = 2,
                  GaleriaId = 11,
                  Descricao = "Imagem de galeria 2",
                  UploadId = 1
              },
              new Imagem()
              {
                  Id = 14,
                  Ordem = 3,
                  GaleriaId = 11,
                  Descricao = "Imagem de galeria 3",
                  UploadId = 1
              },
              new Imagem()
              {
                  Id = 15,
                  Ordem = 4,
                  GaleriaId = 11,
                  Descricao = "Imagem de galeria 4",
                  UploadId = 1
              },
              new Imagem()
              {
                  Id = 16,
                  Ordem = 5,
                  GaleriaId = 11,
                  Descricao = "Imagem de galeria 5",
                  UploadId = 1
              },
              #endregion












            #region Layout imagem e título
              new Imagem()
              {
                  Id = 17,
                  ArtigoId = 5,
                  Ordem = 1,
                  Descricao = "Descrição da imagem",
                  UploadId = 1
              },
              new Titulo()
              {
                  Id = 18,
                  ArtigoId = 5,
                  Ordem = 2,
                  Importancia = 1,
                  Texto = "Layout imagem título e texto"
              },
            #endregion

            #region Layout título e vídeo
              new Titulo()
              {
                  Id = 19,
                  ArtigoId = 6,
                  Ordem = 1,
                  Importancia = 1,
                  Texto = "Layout imagem titulo, texto e vídeo"
              },
              new Video()
              {
                  Id = 20,
                  ArtigoId = 6,
                  Ordem = 2,
                  YoutubeVideoId = "iT6vqeL-ysI"
              },
            #endregion

            #region Layout título e galeria
              new Titulo()
              {
                  Id = 21,
                  ArtigoId = 7,
                  Ordem = 1,
                  Importancia = 1,
                  Texto = "Layout título, texto e galeria"
              },
              new Galeria()
              {
                  Id = 22,
                  ArtigoId = 7,
                  Ordem = 2
              },
              new Imagem()
              {
                  Id = 23,
                  Ordem = 1,
                  GaleriaId = 11,
                  Descricao = "Imagem de galeria 1",
                  UploadId = 1
              },
              new Imagem()
              {
                  Id = 24,
                  Ordem = 2,
                  GaleriaId = 11,
                  Descricao = "Imagem de galeria 2",
                  UploadId = 1
              },
              new Imagem()
              {
                  Id = 25,
                  Ordem = 3,
                  GaleriaId = 11,
                  Descricao = "Imagem de galeria 3",
                  UploadId = 1
              },
              new Imagem()
              {
                  Id = 26,
                  Ordem = 4,
                  GaleriaId = 11,
                  Descricao = "Imagem de galeria 4",
                  UploadId = 1
              },
              new Imagem()
              {
                  Id = 27,
                  Ordem = 5,
                  GaleriaId = 11,
                  Descricao = "Imagem de galeria 5",
                  UploadId = 1
              }
              #endregion
            );

            #endregion;

            #region Alternativas
            #endregion
        }


    }
}
