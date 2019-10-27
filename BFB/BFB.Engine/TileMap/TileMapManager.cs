﻿using System;
using System.Collections.Generic;
using System.Text;

using BFB.Engine.TileMap;

namespace BFB.Engine.TileMap
{

    public class TileMapManager
    {
        //Tile Map will be XCHUNKSxYCHUNKS in size
        private const int XCHUNKS = 30;
        private const int YCHUNKS = 20;
        private const int CHUNKSIZE = 16;
        private Chunk[,] myChunk;

        private int chunkX;
        private int chunkY;
        private int extraX;
        private int extraY;


        public TileMapManager()
        {
            myChunk = new Chunk[XCHUNKS, YCHUNKS];
            chunkX = 0;
            chunkY = 0;
            extraX = 0;
            extraY = 0;

            for (int x = 0; x < XCHUNKS; x++)
            {
                for (int y = 0; y < YCHUNKS; y++)
                {
                    myChunk[x, y] = new Chunk();
                }
            }
        }



        public void createChunkInfo(int x, int y)
        {
            extraX = x % CHUNKSIZE;
            extraY = y % CHUNKSIZE;
            chunkX = x / CHUNKSIZE;
            chunkY = y / CHUNKSIZE;
        }

        #region get 
        public int getHardness(int x, int y)
        {
            createChunkInfo(x, y);
            return myChunk[chunkX,chunkY].getTileHardness(extraX, extraY);
        }

        public int getLight(int x, int y)
        {
            createChunkInfo(x, y);
            return myChunk[chunkX, chunkY].getTileLight(extraX, extraY);
        }

        public int getWall(int x, int y)
        {
            createChunkInfo(x, y);
            return myChunk[chunkX, chunkY].getTileWall(extraX, extraY);
        }

        public int getBlock(int x, int y)
        {
            createChunkInfo(x, y);
            return myChunk[chunkX, chunkY].getTileBlock(extraX, extraY);
        }

        #endregion

        #region set
        public void setHardness(int x, int y, int hardnessValue)
        {
            createChunkInfo(x, y);
            myChunk[chunkX, chunkY].setTileHardness(extraX, extraY, hardnessValue);
        }

        public void setLight(int x, int y, int lightValue)
        {
            createChunkInfo(x, y);
            myChunk[chunkX, chunkY].setTileLight(extraX, extraY, lightValue);
        }

        public void setWall(int x, int y, int wallValue)
        {
            createChunkInfo(x, y);
            myChunk[chunkX, chunkY].setTileWall(extraX, extraY, wallValue);
        }

        public void setBlock(int x, int y, int blockValue)
        {
            createChunkInfo(x, y);
            myChunk[chunkX, chunkY].setTileBlock(extraX, extraY, blockValue);
        }

        public void setAll(int x, int y, int hardnessValue, int lightValue, int wallValue, int blockValue)
        {
            createChunkInfo(x, y);
            myChunk[chunkX, chunkY].setTileHardness(extraX, extraY, hardnessValue);
            myChunk[chunkX, chunkY].setTileLight(extraX, extraY, lightValue);
            myChunk[chunkX, chunkY].setTileWall(extraX, extraY, wallValue);
            myChunk[chunkX, chunkY].setTileBlock(extraX, extraY, blockValue);
        }

        #endregion

    }
}