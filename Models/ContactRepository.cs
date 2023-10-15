using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Models
{
    class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact {ContactId=0, Name="John Doe", Email = "jd00@email.com" },
            new Contact {ContactId=1, Name="Jane Doe", Email = "jd01@email.com"},
            new Contact {ContactId=2, Name="John Smith", Email = "js00@email.com"},
            new Contact {ContactId=3, Name="Jane Smith", Email = "js01@email.com"},
            new Contact {ContactId=4, Name="Phillip Shields", Email = "ps00@email.com"}
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(c => c.ContactId == contactId);

            if (contact != null)
            {
                return new Contact
                {
                    ContactId = contactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Address = contact.Address
                };
            }
            return null;
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId)
                return;

            var contactToUpdate = _contacts.FirstOrDefault(c => c.ContactId == contactId);
            
            if (contactToUpdate != null)
            {
                // automapper for future use, below is very basic
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address = contact.Address;

                //ContactRepository.UpdateContact(contact.ContactId, contact);
                //Shell.Current.GoToAsync("..");
            }
        }
        
        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(c => c.ContactId);
            contact.ContactId = maxId + 1;
            _contacts.Add(contact);
        }

        public static void DeleteContact(int contactId)
        {
            var contactToDelete = _contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contactToDelete != null)
            {
                _contacts.Remove(contactToDelete);
            }
        }


        public static List<Contact> SearchContacts(string searchText)
        {
            

            var filteredContacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.Name) && c.Name.StartsWith(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
            
            
            
            if (filteredContacts == null || filteredContacts.Count == 0)
            {
                filteredContacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.Email) && c.Email.StartsWith(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return filteredContacts;
            }


            if (filteredContacts == null || filteredContacts.Count == 0)
            {
                filteredContacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.Phone) && c.Phone.StartsWith(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return filteredContacts;
            }

            if (filteredContacts == null || filteredContacts.Count == 0)
            {
                filteredContacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.Address) && c.Address.StartsWith(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return filteredContacts;
            }

            return filteredContacts;
        }
    }
}
