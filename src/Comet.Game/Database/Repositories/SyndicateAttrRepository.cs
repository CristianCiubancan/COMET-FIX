﻿// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (C) FTW! Masters
// Keep the headers and the patterns adopted by the project. If you changed anything in the file just insert
// your name below, but don't remove the names of who worked here before.
// 
// This project is a fork from Comet, a Conquer Online Server Emulator created by Spirited, which can be
// found here: https://gitlab.com/spirited/comet
// 
// Comet - Comet.Game - SyndicateAttrRepository.cs
// Description:
// 
// Creator: FELIPEVIEIRAVENDRAMI [FELIPE VIEIRA VENDRAMINI]
// 
// Developed by:
// Felipe Vieira Vendramini <felipevendramini@live.com>
// 
// Programming today is a race between software engineers striving to build bigger and better
// idiot-proof programs, and the Universe trying to produce bigger and better idiots.
// So far, the Universe is winning.
// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#region References

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comet.Game.Database.Models;
using Comet.Shared;

#endregion

namespace Comet.Game.Database.Repositories
{
    public static class SyndicateAttrRepository
    {
        public static async Task<List<DbSyndicateAttr>> GetAsync(uint idSyn)
        {
            await using var db = new ServerDbContext();
            return db.SyndicatesAttr.Where(x => x.SynId == idSyn).ToList();
        }

        public static async Task<bool> SaveAsync(DbSyndicateAttr entity)
        {
            try
            {
                await using var db = new ServerDbContext();
                if (entity.Id == 0)
                    await db.AddAsync(entity);
                else
                    db.Update(entity);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await Log.WriteLogAsync(LogLevel.Exception, ex.ToString());
                return false;
            }
        }

        public static async Task<bool> DeleteAsync(DbSyndicateAttr entity)
        {
            try
            {
                await using var db = new ServerDbContext();
                if (entity.Id == 0)
                    return false;
                db.Remove(entity);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await Log.WriteLogAsync(LogLevel.Exception, ex.ToString());
                return false;
            }
        }
    }
}