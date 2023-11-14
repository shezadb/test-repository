<template>
    <div>

      <div>
        <JqxGrid ref="grid" :width="993" :autoheight="true" @cellendedit="onCellendedit($event)" 
        :theme="'bootstrap'" :editable="true" @cellvaluechanged="onCellvaluechanged($event)"
        :source="dataAdapter" :columns="columns" :altrows="true" />
      </div>
      <div>        
          <JqxButton @click="refreshItems" :template="'success'" :width="80" 
          style="float: left; margin-left: 4px; margin-top: 10px">Refresh</JqxButton>
      </div>
      <div>
          <JqxButton :template="'warning'" :width="80" @click="deleteRecord()"
          style="float: left; margin-left: 4px; margin-top: 10px">Delete</JqxButton>
        
      </div>
      <div>
        <JqxButton v-on:click= "addRecord()" :template="'primary'" :width="80" 
        style="float: left; margin-left: 4px; 
         margin-top: 10px">Add Row</JqxButton>
      
    </div>
    <div>
      <div>
      <button @click="$store.dispatch('incrementCount')" hidden>Increment</button>
      <button @click="$store.dispatch('decrementCount')" hidden>Decrement</button>
      <!-- <div>{{ $store.state.count }}</div> -->
    </div>
    </div>
    </div>
  
</template>

<script>
import JqxButton from 'jqwidgets-scripts/jqwidgets-vue/vue_jqxbuttons.vue';
import JqxGrid from "jqwidgets-scripts/jqwidgets-vue/vue_jqxgrid.vue";
import axios from 'axios';
import servicesds from '../Shared/servicesds.js'
import { store } from '../Shared/store.js'
export default {
  data() {
    return {
        kpiDataItem: [],
        errors: [],
       dataAdapter: new jqx.dataAdapter(this.source,{
    loadComplete: function (data) {
        console.log('data is loaded.')
       // data = data;
         console.log(data); 
         console.log(store.state.count);
       return data;   
    },   
    loadError: function (xhr, status, error) {
        console.log('data is not loaded.')
    }}),
        columns: [
          { text: 'Tag Name', datafield: 'tagName', width: 140},
          { text: 'CurrentValue', datafield: 'currentValue', width: 100 , validation: (cell, value) => {
               if (value < 0 || value > 150) {
                  return { result: false, message: 'Value should be in the 0-150 interval' };
                }
                return true;},},
          { text: 'Monday', datafield: 'monday', width: 100, validation: (cell, value) => {
              if (value < 0 || value > 150) {
                return { result: false, message: 'Value should be in the 0-150 interval' };
              }
              return true;},},
          { text: 'Tuesday', datafield: 'tuesday', width: 100, validation: (cell, value) => {
              if (value < 0 || value > 150) {
                  return { result: false, message: 'Value should be in the 0-150 interval' };
                }
                return true;
              },
          },
          { text: 'Wednesday', datafield: 'wednesday', width: 100, validation: (cell, value) => {
              if (value < 0 || value > 150) {
                return { result: false, message: 'Value should be in the 0-150 interval' };
              }
              return true;},},
          { text: 'Thursday', datafield: 'thursday', width: 100, validation: (cell, value) => {
              if (value < 0 || value > 150) {
                return { result: false, message: 'Value should be in the 0-150 interval' };
              }
              return true;},},
          { text: 'Friday', datafield: 'friday', width: 100, validation: (cell, value) => {
              if (value < 0 || value > 150) {
                return { result: false, message: 'Value should be in the 0-150 interval' };
              }
              return true;},},
          { text: 'Saturday', datafield: 'saturday', width: 100, validation: (cell, value) => {
              if (value < 0 || value > 150) {
                return { result: false, message: 'Value should be in the 0-150 interval' };
              }
              return true;},},
          { text: 'Sunday', datafield: 'sunday', width: 100, validation: (cell, value) => {
              if (value < 0 || value > 150) {
                return { result: false, message: 'Value should be in the 0-150 interval' };
              }
              return true;},},
              { text: 'id', datafield: 'id', width: 50},
        ],
    }
  },
  
  async beforeCreate() {

     // this. source1 =  this.loadItems();
      this.source = {      
        datatype: 'json',
        datafields: [
          { name: 'tagName', type: 'string' },
          { name: 'currentValue', type: 'float' },
          { name: 'monday', type: 'float' },
          { name: 'tuesday', type: 'float' },
          { name: 'wednesday', type: 'float' },
          { name: 'thursday', type: 'float'},
          { name: 'friday', type: 'float'},
          { name: 'saturday', type: 'float'},
          { name: 'sunday', type: 'float'},
          { name: 'id', type: 'int'}
        ],
        url: 'http://localhost:5000/api/kpvitem',
       // root: 'data',

        contenttype: 'application/json',
       // root: 'data',
       //type: 'GET',
        
      };
    },
   components: {
      JqxGrid,JqxButton, 
    },
    methods: {
        onCellendedit: function (event) {
          this.kpiDataItem = event.args.row;
       // console.log(event.args.row);
      //  this.updateValues(event.args.row,event.args.row.uid);
      },
      
      addRecord() {
        const value = this.$refs.grid.getrows();
         var firstColumnData = [];
         var result = "";
          for (var i = 0; i < value.length; i++) {
            firstColumnData.push(value[i].id);
          }
       // alert(Math.max.apply(Math, firstColumnData));
        var nextId = Math.max.apply(Math, firstColumnData) + 1;
       // var rowCount = value.length;
        const newWeek = {  "id": nextId,
                            "tagName": "Tag ??",
                            "currentValue":0,
                            "monday":0,
                            "tuesday":0,
                            "wednesday":0,
                            "thursday":0,
                            "friday":0,
                            "saturday":0,
                            "sunday":0};

        //console.log("add row")
        //console.log(this.$refs.grid);
        servicesds.addValuesAxios(newWeek);
        this.refreshItems();
        //console.log(this.$refs.grid.getrowdata(0));
      },
      deleteRecord() {
        console.log("delete pressed");
        const rowIndex = this.$refs.grid.getselectedrowindex();
        const rowData = this.$refs.grid.getrowdata(rowIndex);
        console.log(rowData);
        servicesds.deleteValuesAxios(rowData, rowData.id);
        this.refreshItems();
      },
      onCellvaluechanged: function (event) {
        console.log(event.args);
        console.log(this.kpiDataItem);
      //  alert('do something...');
        console.log('check');
        console.log(this.kpiDataItem.id)
        servicesds.updateValuesCellAxios(this.kpiDataItem,this.kpiDataItem.id);
      },
      refreshItems() {
        console.log("aaa");
        this.$refs.grid.updatebounddata();
        console.log("ddd");
        
      },
    

    async loadItems() {
        this.source = {      
        datatype: 'json',
        datafields: [
          { name: 'tagName', type: 'string' },
          { name: 'currentValue', type: 'float' },
          { name: 'monday', type: 'float' },
          { name: 'tuesday', type: 'float' },
          { name: 'wednesday', type: 'float' },
          { name: 'thursday', type: 'float'},
          { name: 'friday', type: 'float'},
          { name: 'saturday', type: 'float'},
          { name: 'sunday', type: 'float'},
          { name: 'ID', type: 'int'}
        ],
        url: 'http://localhost:5000/api/kpvitem',
        contenttype: 'application/json',
      };
      
        return this.source;
    },
  }
}
</script>
<style src='../assets/styles/jqwidgets/jqx.base.css'></style>
<style src='../assets/styles/jqwidgets/jqx.bootstrap.css'></style>