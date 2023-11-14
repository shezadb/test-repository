<template>
    <div style="height: 45px;">
        <JqxMenu ref="myMenu" :width="993"  :height="30">
            <ul>
                <li><a href="Home">Home</a></li>
                <li><a href="About">About</a></li>
            </ul>
        </JqxMenu>
    </div>
</template>

<script>
     import JqxMenu from "jqwidgets-scripts/jqwidgets-vue/vue_jqxmenu.vue";

     export default {
        components: {
            JqxMenu
        }
     }
</script>
