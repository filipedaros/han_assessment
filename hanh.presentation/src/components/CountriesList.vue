<template>
    <div>
        <DataTable class="display" :columns="columns" :data="countries">
            <template #column-0="props">
                <img :src="props.cellData" style="max-height: 20px;">
            </template>
        </DataTable>
    </div>
</template>

<script>
import api from '@/services/api.js';


import DataTable from 'datatables.net-vue3';
import DataTablesCore from 'datatables.net-dt';
 
DataTable.use(DataTablesCore);

export default {

    name: "CountriesList",

    components: {
        DataTable
    },

    data() {
        return {
            countries: [],
            columns: [
                { data: 'flag', title: 'Flag' },
                { data: 'name', title: 'Name' },
                { data: 'capital', title: 'Capital' },
                { data: 'region', title: 'Region' },
                { data: 'subregion', title: 'Subregion' },
                { data: 'area', title: 'Area' },
                { data: 'population', title: 'Population' },
                { data: 'currency', title: 'Currency' },
            ]
        }
    },
    mounted() {
        //Get data from the .net core web API
        api.get('/countries').then(response => {
            this.countries = response.data;
        });
    }
}
</script>

<style scoped>
@import 'datatables.net-dt';
</style>