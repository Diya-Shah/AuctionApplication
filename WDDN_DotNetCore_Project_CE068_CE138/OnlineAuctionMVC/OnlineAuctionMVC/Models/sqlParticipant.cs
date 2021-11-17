using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Models
{
    public class sqlParticipant
    {
        
            private readonly AppDbContext context;
            public sqlParticipant(AppDbContext context)
            {
                this.context = context;
            }

            public void Add(int Bid,int Pid,string name,int amount)
            {
            Participant participant = new Participant();
            participant.Bid = Bid;
            participant.Pid = Pid;
            participant.bidderName = name;
            participant.bidAmount = amount;
                context.Participants.Add(participant);
                context.SaveChanges();
            }
            public IEnumerable<Participant> GetAllParticipants(int PId)
            {
                return context.Participants.Where(x => x.Pid == PId).OrderByDescending(x=>x.bidAmount);
            }
            public int getBidAmount(int Pid)
            {
                IEnumerable<Participant> p = context.Participants.Where(x=>x.Pid == Pid);
                int x = p.Max(x => x.bidAmount);
                return x;
            }

            public Participant getWinner(int Pid)
            {
                IEnumerable<Participant> p = context.Participants.Where(x => x.Pid == Pid);
                int x = p.Max(x => x.bidAmount);
            
            return context.Participants.FirstOrDefault(r => r.Pid == Pid && r.bidAmount == x);


            }
        public void Update(int Pid,int Bid,int bidAmount)
            {
            Participant p = context.Participants.FirstOrDefault(x => x.Bid == Bid && x.Pid == Pid);
            p.bidAmount = bidAmount;
            context.SaveChanges();
            }
    }
}
