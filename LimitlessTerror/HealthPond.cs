using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitlessTerror
{
    class HealthPond
    {
        private int[] Max_HealthPond = new int[4];//1-4,full-A
        private int[] CurrentHealthPond = new int[4];
        public bool Alive = true;

        public void Die()
        {
            this.Alive = false;
        }
        public HealthPond(int MaxHealth)
        {
            for (int i = 0; i < 4; i++)
            {
                Max_HealthPond[i] = MaxHealth;
            }
            CurrentHealthPond[0] = MaxHealth;
            CurrentHealthPond[1] = 0;
            CurrentHealthPond[2] = 0;
            CurrentHealthPond[3] = 0;
        }
        public void LostBPond()
        {
            Max_HealthPond[1] = -1;
        }
        public void LostAPond()
        {
            Max_HealthPond[3] = -1;
        }
        private bool TakeOneDamage(int x)
        {
            if (x > 2)
            {
                return false;
            }
            for (int i = 0; i < x; i++)
            {
                if (CurrentHealthPond[i] > 0)
                {
                    CurrentHealthPond[i]--;
                    CurrentHealthPond[x + 1]++;
                    return true;
                }
            }
            return TakeOneDamage(x + 1);
        }
        public bool CurseDamage(int[] Damage)
        {
            if (Max_HealthPond[3] == -1)
            {
                Damage[1] += Damage[2];
                Damage[2] = 0;
            }
            if (Max_HealthPond[1] == -1)
            {
                Damage[1] += Damage[0];
                Damage[0] = 0;
            }
            for (int i = 0; i < 3; i++)
            {
                while (Damage[i] > 0)
                {
                    if (TakeOneDamage(i))
                    {
                        Damage[i]--;
                    }
                    else
                    {
                        Die();
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
