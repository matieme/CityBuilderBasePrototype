using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GridTests
    {
        [Test]
        //MethodName_WhenTheseConditions_DoesWhat
        public void SetGridCellData_PassValidData_CellInPositionIsEqualToRoad()
        {
            //Arrange
            GridCellLayout gridCell = new GridCellLayout(10, 10);
            Vector3Int position = new Vector3Int(1, 0, 1);
            
            //Act
            gridCell.SetGridCellData(position, CellType.Road);
            
            //Assert
            Assert.That(gridCell.GetGridCellByPosition(position).Type, Is.EqualTo(CellType.Road));
        }

        [TestCase(5, 5)]
        [TestCase(9, 4)]
        [TestCase(5, 8)]
        public void CreateGridData_PassWidthAndHeight_GetValidCellData(int value1, int value2)
        {
            int gridSize = 10;
            Vector3Int position = new Vector3Int(value1, 0, value2);
            
            GridCellLayout gridCell = new GridCellLayout(gridSize, gridSize);

            Assert.That(gridCell.GetGridCellByPosition(position), Is.Not.Null);
        }

        [Test]
        public void GetAllAdjacentCellTypes_CreateRoadsAround_GetValidAdjacentCellData()
        {
            GridCellLayout gridCell = new GridCellLayout(10, 10);
            Vector3Int position = new Vector3Int(1, 0, 0);
            gridCell.SetGridCellData(position, CellType.Road);
            Vector3Int position2 = new Vector3Int(0, 0, 1);
            gridCell.SetGridCellData(position2, CellType.Road);
            Vector3Int position3 = new Vector3Int(2, 0, 1);
            gridCell.SetGridCellData(position3, CellType.Road);
            Vector3Int position4 = new Vector3Int(1, 0, 2);
            gridCell.SetGridCellData(position4, CellType.Road);
            
            CellType[] cells = gridCell.GetAllAdjacentCellTypes(1,1);
            int roadCounter = 0;
            
            foreach (var cellType in cells)
            {
                if (cellType == CellType.Road)
                {
                    roadCounter++;
                }
            }

            Assert.That(roadCounter, Is.EqualTo(4));
        }
    }
}
