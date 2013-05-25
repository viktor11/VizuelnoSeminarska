using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace probaOdbivanje
{
    class CiglaDoc
    {
        public List<Cigla> lstCigli;

        public CiglaDoc()
        {
            lstCigli = new List<Cigla>();
        }

        public void brisi(Cigla c)
        {
            lstCigli.Remove(c);
        }

        public void drawAll(Graphics g)
        {
            foreach (Cigla item in lstCigli)
            {
                item.draw(g);
            }

        }
    }
}
