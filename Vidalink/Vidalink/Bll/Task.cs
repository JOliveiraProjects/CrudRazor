using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Vidalink.Models;

namespace Vidalink.Bll
{
    public class Task : VidalinkBase
    {
        public List<Data.Task> ListActive()
        {
            using (var db = Context())
            {
                return db.Task.Where(x => x.Active).ToList();
            }
        }

        public List<Data.Task> ListTaskLastExceDate(int qtd)
        {
            //return ListActive().Where(x => DbFunctions.TruncateTime(x.ExecDate) <= DbFunctions.TruncateTime(DateTime.Today) 
            //    && DbFunctions.TruncateTime(x.ExecDate) <= DbFunctions.TruncateTime(DateTime.Today))
            //    .Take(qtd)
            //    .OrderByDescending(x => x.ExecDate).ToList();

            using (var db = Context())
            {
                return (from s in db.Task
                 where s.Active
                 && DbFunctions.TruncateTime(s.ExecDate) <= DateTime.Today.Date
                 orderby s.ExecDate descending
                 select s
                    ).Take(qtd).ToList();
            }

        }

        public List<Data.Task> ListAll()
        {
            using (var db = Context())
            {
                return db.Task.OrderBy(x => x.Title).ToList();
            }
        }

        public virtual Data.Task Get(int taskId)
        {
            using (var db = Context())
            {
                return db.Task.FirstOrDefault(x => x.TaskId == taskId);
            }
        }

        public List<Data.Task> Search(string text)
        {
            return ListActive().Where(x => x.Title.Contains(text) || x.Description.Contains(text)).ToList();
        }

        public Data.Task GetByTitle(string title)
        {
            return ListAll().FirstOrDefault(x => x.Title == title);
        }

        public virtual Data.Task SaveTask(Data.Task model)
        {
            using (var db = Context())
            {
                Data.Task modelResult;
                if (model.TaskId > 0)
                {
                    modelResult = db.Task.FirstOrDefault(x => x.TaskId == model.TaskId);
                    if (modelResult == null)
                        return null;
                    modelResult.Active = model.Active;
                    modelResult.Title = model.Title;
                    modelResult.Description = model.Description;
                    modelResult.ExecDate = model.ExecDate;
                    modelResult.Description = model.Description;
                    modelResult.UserId = model.UserId;
                    db.Entry(modelResult).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Task.Add(model);
                    db.SaveChanges();

                    modelResult = model;
                }

                return modelResult;
            }
        }

        public bool DeleteTask(int id)
        {
            try
            {
                using (var db = Context())
                {
                    if (id > 0)
                    {
                        var mod =
                            db.Task.FirstOrDefault(x => x.TaskId == id);
                        if (mod != null)
                        {
                            db.Task.Remove(mod);
                            db.SaveChanges();
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
