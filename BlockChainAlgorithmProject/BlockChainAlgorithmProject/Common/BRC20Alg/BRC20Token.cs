using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.BRC20Alg
{
    public class BRC20Token
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public uint TotalSupply { get; set; }
        public Dictionary<string, uint> Balances { get; set; }

        public BRC20Token(string name, string symbol, uint totalSupply)
        {
            this.Name = name;
            this.Symbol = symbol;
            this.TotalSupply = totalSupply;
            this.Balances = new Dictionary<string, uint>();
        }

        public bool Mint(string address, uint amount)
        {
            if (amount > this.TotalSupply)
            {
                return false;
            }

            this.Balances[address] = (this.Balances.ContainsKey(address) ? this.Balances[address] + amount : amount);
            this.TotalSupply -= amount;
            return true;
        }

        public bool Transfer(string fromAddress, string toAddress, uint amount)
        {
            if (!this.Balances.ContainsKey(fromAddress) || this.Balances[fromAddress] < amount)
            {
                return false;
            }

            this.Balances[fromAddress] -= amount;
            this.Balances[toAddress] = (this.Balances.ContainsKey(toAddress) ? this.Balances[toAddress] + amount : amount);
            return true;
        }

        public uint BalanceOf(string address)
        {
            if (!this.Balances.ContainsKey(address))
            {
                return 0;
            }

            return this.Balances[address];
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}