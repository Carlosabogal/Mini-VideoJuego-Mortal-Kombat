using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameDesktopGL
{
    public class Disparo
    {
        Texture2D tex;
        Vector2 posicion;
        public Rectangle rect;
        SpriteBatch spriteBatch;
        public bool estaVivo = true;

        public Disparo(
            Texture2D _tex,
            Vector2 _posicion,
            SpriteBatch _spriteBatch)
        {
            tex = _tex;
            posicion = _posicion;
            spriteBatch = _spriteBatch;

            rect = new Rectangle((int)posicion.X, (int)posicion.Y, 20, 20);
        }

        public void Update()
        {
            rect.Y -= 3;
        }

        public void Draw()
        {
            spriteBatch.Draw(tex, rect, Color.White);
        }

        public void Eliminar()
        {
            estaVivo = false;
        }
    }
}
