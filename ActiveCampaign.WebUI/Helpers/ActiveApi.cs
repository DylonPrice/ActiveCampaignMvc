using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using ActiveCampaign.Domain.Entities;
using ActiveCampaignNet;
using Newtonsoft.Json.Linq;

namespace ActiveCampaign.WebUI.Helpers
{
    public class ActiveApi
    {
        // Client comes from ActiveCampaignNet NuGet package
        // Client instance is created using API Key/URL in development section of ActiveCampaign Website
        ActiveCampaignClient client = new ActiveCampaignClient("3abff1c87ad096a1de9952120790451170cb2001cb4329cb549cbde3d5f55dbd7358d6d2", "https://xanatek27729.api-us1.com");

        // Lists

        public List AddList(List list)
        {
            JObject jResult = new JObject();
            var result = client.Api("list_add", new NameValueCollection
            {
                {"api_output", "json" },
                {"name", list.Name },
                {"to_name", list.ToName },
                {"subscription_notify", list.SubscriptionNotify },
                {"unsubscription_notify", list.UnsubscriptionNotify },
                {"carboncopy", list.CarbonCopy },
                {"sender_name", "Xanatek" },
                {"sender_addr1", "412 South Lafayette Blvd" },
                {"sender_zip", "46601" },
                {"sender_city", "South Bend" },
                {"sender_country", "United States" },
                {"sender_url", "http://www.xanatek.com" },
                {"sender_reminder", "Test reminder" },
            });

            if (result.IsSuccessful)
            {
                jResult = JObject.Parse(result.Data);
                list.Id = (string) jResult["id"];
                return list;
            }

            return null;
        }

        public bool EditList(List list)
        {
            var result = client.Api("list_edit", new NameValueCollection
            {
                {"api_output", "json" },
                {"id", list.Id },
                {"name", list.Name },
                {"subscription_notify", list.SubscriptionNotify },
                {"unsubscription_notify", list.UnsubscriptionNotify },
                {"to_name", list.ToName },
                {"carboncopy", list.CarbonCopy },
                {"sender_name", "Xanatek" },
                {"sender_addr1", "412 South Lafayette Blvd" },
                {"sender_zip", "46601" },
                {"sender_city", "South Bend" },
                {"sender_country", "United States" },
                {"sender_url", "http://www.xanatek.com" },
                {"sender_reminder", "Test reminder" },
            });

            if (result.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public bool DeleteList(List list)
        {
            var result = client.Api("list_delete", new NameValueCollection
            {
                {"id", list.Id },
            });

            if (result.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public List<List> GetLists(string listIds)
        {
            var jResult = new JObject();
            var lists = new List<List>();
            var result = client.Api("list_list", new NameValueCollection
            {
                {"api_output", "json" },
                {"ids", listIds },
                {"full", "1" }
            });

            if (result.IsSuccessful)
            {
                jResult = JObject.Parse(result.Data);
                foreach (var child in jResult)
                {
                    if (child.Key == "result_code" || child.Key == "result_message" || child.Key == "result_output")
                    {
                        break;
                    }
                    var jsonList = child.Value;
                    var list = CreateList(jsonList);
                    lists.Add(list);
                }
            }

            return lists;
        }

        //Contacts

        public List<Contact> GetContacts(string contactIds)
        {
            var jResult = new JObject();
            var contacts = new List<Contact>();
            var result = client.Api("contact_list", new NameValueCollection
            {
                {"api_output", "json" },
                {"ids", contactIds },
                {"full", "1" }
            });

            if (result.IsSuccessful)
            {
                jResult = JObject.Parse(result.Data);
                foreach (var child in jResult)
                {
                    if (child.Key == "result_code" || child.Key == "result_message" || child.Key == "result_output")
                    {
                        break;
                    }
                    var jsonContact = child.Value;
                    var contact = CreateContact(jsonContact);
                    contacts.Add(contact);
                }
            }
            return contacts;
        }

        public Contact AddContact(Contact contact)
        {
            var jResult = new JObject();
            var result = client.Api("contact_add", new NameValueCollection
            {
                {"api_output", "json" },
                {"email", contact.Email },
                {"first_name", contact.FirstName },
                {"last_name", contact.LastName },
                {"p[" + contact.ListId + "]", contact.ListId }
            });

            if (result.IsSuccessful)
            {
                jResult = JObject.Parse(result.Data);
                contact.Id = (string)jResult["subscriber_id"];
                return contact;
            }
            return null;
        }

        public bool EditContact(Contact contact)
        {
            var result = client.Api("contact_edit", new NameValueCollection
            {
                {"api_output", "json" },
                {"id", contact.Id },
                {"email", contact.Email },
                {"first_name", contact.FirstName },
                {"last_name", contact.LastName },
                {"p[" + contact.ListId + "]", contact.ListId }
            });

            if (result.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public bool DeleteContact(Contact contact)
        {
            var result = client.Api("contact_delete", new NameValueCollection
            {
                {"id", contact.Id },
            });

            if (result.IsSuccessful)
            {
                return true;
            }
            return false;
        }

        //Messages

        public Message AddMessage(Message message)
        {
            var jResult = new JObject();
            var result = client.Api("message_add", new NameValueCollection
            {
                {"api_output", "json" },
                {"format", message.Format },
                {"subject", message.Subject },
                {"fromemail", message.FromEmail },
                {"fromname", message.FromName },
                {"reply2", message.ReplyTo },
                {"priority", message.Priority },
                {"charset", "utf-8" },
                {"encoding", "quoted-printable" },
                {"htmlconstructor", "editor" },
                {"html", message.Body },
                {"textconstructor", "editor" },
                {"text", message.Body },
                {"p[" + message.ListId + "]", message.ListId }
            });

            if (result.IsSuccessful)
            {
                jResult = JObject.Parse(result.Data);
                message.Id = (string) jResult["id"];
                return message;
            }
            return null;
        }

        public List<Message> GetMessages(string messageIds)
        {
            var jResult = new JObject();
            var messages = new List<Message>();
            var result = client.Api("message_list", new NameValueCollection
            {
                {"api_output", "json"},
                {"ids", messageIds},
                {"page", "1"}
            });

            if (result.IsSuccessful)
            {
                jResult = JObject.Parse(result.Data);
                foreach (var child in jResult)
                {
                    if (child.Key == "result_code" || child.Key == "result_message" || child.Key == "result_output")
                    {
                        break;
                    }
                    var jsonMessage = child.Value;
                    var message = CreateMessage(jsonMessage);
                    messages.Add(message);
                }
            }
            return messages;
        }

        public bool EditMessage(Message message)
        {
            var result = client.Api("message_edit", new NameValueCollection
            {
                {"api_output", "json" },
                {"id", message.Id },
                {"format", message.Format },
                {"subject", message.Subject },
                {"fromemail", message.FromEmail },
                {"fromname", message.FromName },
                {"reply2", message.ReplyTo },
                {"priority", message.Priority },
                {"charset", "utf-8" },
                {"encoding", "quoted-printable" },
                {"htmlconstructor", "editor" },
                {"html", message.Body },
                {"textconstructor", "editor" },
                {"text", message.Body },
                {"p[" + message.ListId + "]", message.ListId },
            });

            if (result.IsSuccessful)
            {
                return true;
            }
            return false;
        }

        public bool DeleteMessage(Message message)
        {
            var result = client.Api("message_delete", new NameValueCollection
            {
                {"id", message.Id }
            });

            if (result.IsSuccessful)
            {
                return true;
            }
            return false;
        }

        // Campaigns

        public Campaign AddCampaign(Campaign campaign)
        {
            var jResult = new JObject();
            var result = client.Api("campaign_create", new NameValueCollection
            {
                {"type", campaign.Type },
                {"name", campaign.Name },
                {"sdate", campaign.SendDate.ToString("s") },
                {"status", campaign.Status },
                {"public", campaign.IsPublic },
                {"tracklinks", campaign.LinkTracking },
                {"m[" + campaign.MessageId + "]", "100" },
                {"p[" + campaign.ListIds + "]", campaign.ListIds }
            });

            if (result.IsSuccessful)
            {
                jResult = JObject.Parse(result.Data);
                campaign.Id = (string) jResult["id"];
                return campaign;
            }
            return null;
        }

        private List CreateList(JToken listObject)
        {
            var list = new List
            {
                Id = (string) listObject["id"],
                Name = (string) listObject["name"],
                ToName = (string) listObject["to_name"],
                SubscriptionNotify = (string) listObject["subscription_notify"],
                UnsubscriptionNotify = (string) listObject["unsubscription_notify"],
                CarbonCopy = (string) listObject["carboncopy"]
            };

            return list;
        }

        private Contact CreateContact(JToken contactObject)
        {
            var contact = new Contact
            {
                Id = (string) contactObject["id"],
                FirstName = (string) contactObject["first_name"],
                LastName = (string) contactObject["last_name"],
                Email = (string) contactObject["email"],
                ListId = (string) contactObject["listid"]
            };

            return contact;
        }

        private Message CreateMessage(JToken messageObject)
        {
            var message = new Message
            {
                Id = (string) messageObject["id"],
                Format = (string) messageObject["format"],
                Subject = (string) messageObject["subject"],
                FromEmail = (string) messageObject["fromemail"],
                FromName = (string) messageObject["fromname"],
                ReplyTo = (string) messageObject["reply2"],
                Priority = (string) messageObject["priority"]
            };

            if (message.Format == "text")
            {
                message.Body = (string) messageObject["text"];
            }
            if (message.Format == "html")
            {
                message.Body = (string) messageObject["html"];
            }

            return message;
        }
    }
}