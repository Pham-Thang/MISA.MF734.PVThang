<template>
    <div id="content">
        <FeeList />
    </div>
</template>
<script>
import FeeList from '../views/planning/FeeList'

export default {
    components: {
        FeeList
    }
}
</script>
<style>
#content {
    position: absolute;
    top: 50px;
    left: 205px;
    right: 0;
    bottom: 0;
    width: calc(100% - 205px);
    height: calc(100vh - 50px);
}
</style>