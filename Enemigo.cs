using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameDesktopGL
{
    public class Enemigo
    {
        Texture2D tex;
        public Rectangle rect;
        Vector2 posicion;
        Vector2 velocidad;
        SpriteBatch spriteBatch;
        public bool estaVivo = true;

        //MOVIMIENTO "INTELIGENTE"
        Random random = new Random();        
        int tipoMovimiento = 0;
        bool mover = false;
        int contadorMovimiento = 0;
        int limiteMovimiento = 100;
        int velocidadY;
        int velocidadX = 1;

        public Enemigo(
            Texture2D _tex,
            Vector2 _posicion,
            Vector2 _velocidad,
            SpriteBatch _spriteBatch)
        {
            tex = _tex;
            posicion = _posicion;
            velocidad = _velocidad;
            spriteBatch = _spriteBatch;

            tipoMovimiento = random.Next(0, 2);
            velocidadY = (int)velocidad.Y;
            rect = new Rectangle((int)posicion.X, (int)posicion.Y, 50, 50);
        }

        public void Eliminar()
        {
            estaVivo = false;
        }

        public void Update()
        {            
            rect.Y += velocidadY;
            Movimientos();
            CambiarMovimiento();
        }

        private void CambiarMovimiento()
        {
            contadorMovimiento++;
            if(contadorMovimiento >= limiteMovimiento)
            {
                mover = !mover;
                contadorMovimiento = 0;
                limiteMovimiento = random.Next(1, 300);
                velocidadY = random.Next(1, 5);
                velocidadX = random.Next(1, 5);
            }
        }

        private void Movimientos()
        {
            if(tipoMovimiento == 0)
            {
                if (mover)
                {
                    rect.X += velocidadX;
                }
                else
                {
                    rect.X -= velocidadX;
                }
                
            }
            else
            {
                if (mover)
                {
                    rect.X -= velocidadX;
                }
                else
                {
                    rect.X += velocidadX;
                }
            }
        }

        public void Draw()
        {
            spriteBatch.Draw(tex, rect, Color.White);
        }
    }
}
