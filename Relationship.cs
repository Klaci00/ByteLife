using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    public class Relationship
    {
        public Person Person1 { get; set; }
        public Person Person2 { get; set; }
        public int Condition { get; set; }

        public string Description { get; set; }

        public Relationship(Person person1, Person person2, int condition, string description)
        {
            Person1 = person1;
            Person2 = person2;
            Condition = condition;
            Description = description;
        }



        public static void RelationshipRenderer(Person player, Person npc, string description)
        {
            Relationship relationship = new(player, npc, 100, description);
            Relationship relationship1 = new(npc, player, 100, description);
            player.Relationships.Add(relationship);
            npc.Relationships.Add(relationship1);
        }

        public static void FamilyRelationshipRenderer(Person player, Person father, Person mother, List<Person> siblings)
        {
            Relationship playerFather = new(player, father, 100, "father");
            player.Relationships.Add(playerFather);

            Relationship fatherPlayer = new(father, player, 100, player.Female ? "daughter" : "son");
            father.Relationships.Add(playerFather);

            Relationship playerMother = new(player, mother, 100, "mother");
            player.Relationships.Add(playerMother);

            Relationship motherPlayer = new(mother, player, 100, player.Female ? "daughter" : "son");

            Relationship fatherMother = new(father, mother, 100, "wife");
            father.Relationships.Add(fatherMother);

            Relationship motherFather = new(mother, father, 100, "husband");
            mother.Relationships.Add(fatherMother);

            foreach (Person sibling in siblings)
            {
                Relationship siblingFather = new(sibling, father, 100, "father");
                sibling.Relationships.Add(siblingFather);

                Relationship fatherSibling = new(father, sibling, 100, sibling.Female ? "daughter" : "son");
                father.Relationships.Add(fatherSibling);

                Relationship siblingMother = new(sibling, mother, 100, "mother");
                sibling.Relationships.Add(siblingMother);

                Relationship motherSibling = new(mother, sibling, 100, sibling.Female ? "daughter" : "son");
                mother.Relationships.Add(motherSibling);

                Relationship playerSibling = new(player, sibling, 100, sibling.Female ? "sister" : "brother");
                player.Relationships.Add(playerSibling);

                Relationship siblingPlayer = new(sibling, player, 100, player.Female ? "sister" : "brother");
                sibling.Relationships.Add(siblingPlayer);

            }


            for (int i = 0; i < siblings.Count - 1; i++)
            {
                for (int j = 0; j < siblings.Count; j++)
                {
                    j = j == i ? +1 : j;
                    Relationship relationship = new(siblings[i], siblings[j], 100, siblings[j].Female ? "sister" : "brother");
                    siblings[i].Relationships.Add(relationship);
                }
            }


        }
    }

}
