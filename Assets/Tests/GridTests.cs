using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using NUnit.Framework;
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
    }
}
